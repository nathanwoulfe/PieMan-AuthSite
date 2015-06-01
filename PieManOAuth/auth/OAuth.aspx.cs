
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var redirectUri = "http://pieman-auth.azurewebsites.net/auth/OAuth.aspx";

        if (Request.QueryString["do"] == null && Request.QueryString["code"] == null)
        {
            Session["callback"] = Request.QueryString["clientcallback"];
            Session["state"] = Request.QueryString["clientstate"];            
            link.NavigateUrl = "?do=login&clientcallback=" + Session["callback"] + "&state=" + Session["state"];            
        }

        else if (Request.QueryString["do"] != null)
        {
            // The query string to send to the authentication site
            NameValueCollection nvc = new NameValueCollection {
                {"response_type", "code"},
                {"client_id", "140468485447-dgk7rqv982gqk9ao9gbsck7epq0pu8ad.apps.googleusercontent.com"},
                {"redirect_uri", redirectUri},
                {"scope", "profile https://www.googleapis.com/auth/analytics.readonly"},
                {"approval_prompt", "force"},
                {"access_type","offline"}
            };

            var q = String.Join("&", nvc.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(nvc[a])));

            // Generate the URL for the authentication page
            string oAuthUrl = "https://accounts.google.com/o/oauth2/auth?" + q;

            Response.Redirect(oAuthUrl);
        }

        if (Request.QueryString["code"] != null)
        {
            //retreive 'code value' from query string.
            var codeValue = Request["code"];

            //If Google has sent us a 'code value' after authenticating the user,
            //we will use this code to request an access token.
            if (codeValue != null)
            {
                //Create a post request for to request an access token
                WebClient client = new WebClient();

                // creates the post data for the POST request
                System.Collections.Specialized.NameValueCollection values = new System.Collections.Specialized.NameValueCollection();
                values.Add("client_id", "140468485447-dgk7rqv982gqk9ao9gbsck7epq0pu8ad.apps.googleusercontent.com");
                values.Add("client_secret", "90mdgzToSN9cc0H17Ic_9TsN");
                values.Add("redirect_uri", redirectUri);
                values.Add("code", codeValue);
                values.Add("grant_type", "authorization_code");

                // Post Request
                byte[] response = client.UploadValues("https://accounts.google.com/o/oauth2/token", values);
                var TokenInformation = System.Text.Encoding.UTF8.GetString(response);
                dynamic TokenObject = JsonConvert.DeserializeObject(TokenInformation);

                Response.Redirect(String.Format("{0}?state={1}&token={2}", Session["callback"].ToString(), Session["state"].ToString(), TokenObject.refresh_token));


            }


            Response.Redirect(Session["clientcallback"].ToString());
        }
    }
}