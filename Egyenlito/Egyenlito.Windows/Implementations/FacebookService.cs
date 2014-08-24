using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using Facebook;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Security.Authentication.Web;
using Windows.UI.Core;
using Windows.UI.Popups;

namespace Egyenlito.Implementations
{
    class FacebookService : IFacebookService
    {
        public string App_Id { get; set; }
        public string ExtendedPermissions { get; set; }
        public FacebookClient Client { get; set; }
        public CoreDispatcher Dispatcher { get; set; }

        public Article Article { get; set; }
        public Newspaper Newspaper { get; set; }


        public FacebookService()
        {
            App_Id = "299288850253625";
            ExtendedPermissions = "publish_actions";

            Client = new FacebookClient();
            Dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        }


        public async void Share(Article article, Newspaper newspaper)
        {
            try
            {
                Article = article;
                Newspaper = newspaper;

                if (!IsInternetConnected())
                {
                    ShowMessage("Nincs internet kapcsolat!");
                }
                else
                {
                    var redirectUrl = "https://www.facebook.com/connect/login_success.html";

                    var loginUrl = Client.GetLoginUrl(new
                    {
                        client_id = App_Id,
                        redirect_uri = redirectUrl,
                        scope = ExtendedPermissions,
                        display = "popup",
                        response_type = "token"
                    });

                    var endUri = new Uri(redirectUrl);

                    WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, loginUrl, endUri);

                    if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                    {
                        var callbackUri = new Uri(WebAuthenticationResult.ResponseData.ToString());
                        var facebookOAuthResult = Client.ParseOAuthCallbackUrl(callbackUri);
                        var accessToken = facebookOAuthResult.AccessToken;
                        if (String.IsNullOrEmpty(accessToken))
                        {
                            // User is not logged in, they may have canceled the login
                        }
                        else
                        {
                            // User is logged in and token was returned
                            LoginSucceded(accessToken);
                        }
                    }
                }
            }
            catch
            {
                ShowMessage("Hiba történt!");
            }
        }

        private async void LoginSucceded(string accessToken)
        {
            dynamic parameters = new ExpandoObject();
            parameters.access_token = accessToken;
            parameters.fields = "id";

            Client = new FacebookClient(accessToken);

            dynamic result = await Client.GetTaskAsync("me", parameters);
            parameters = new ExpandoObject();
            parameters.id = result.id;
            parameters.access_token = accessToken;

            await Post();
        }

        public async Task Post()
        {
            try
            {
                var parameters = new Dictionary<string, object>();

                parameters["link"] = Article.PdfUri;
                parameters["picture"] = Newspaper.CoverUri;
                parameters["name"] = Article.Title;

                Client.PostCompleted += Client_PostCompleted;
                dynamic result = await Client.PostTaskAsync("me/feed", parameters);
            }
            catch
            {
                ShowMessage("Hiba történt!");
            }
        }

        void Client_PostCompleted(object sender, FacebookApiEventArgs e)
        {
            if (e.Error != null)
            {
                ShowMessage("Hiba történt!");
            }
            else
            {
                ShowMessage("A cikket sikeresen megosztottad!");
            }
        }

        private async void ShowMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                MessageDialog mesg = new MessageDialog(message);
                await mesg.ShowAsync();
            });
        }

        private bool IsInternetConnected()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            return (connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }
    }
}
