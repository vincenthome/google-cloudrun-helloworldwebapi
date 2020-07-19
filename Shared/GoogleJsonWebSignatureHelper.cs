using System;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Helper {
    public static class GoogleJsonWebSignatureHelper {
        const string CLIENT_ID = "558239320168-fvq1q2ircqqhnjrhpdi18ivqrg8hlnci.apps.googleusercontent.com";

        public static async System.Threading.Tasks.Task<MyPayload> VerifyIdTokenAsync (string token) {

            Payload payload = await ValidateAsync(token);
            if (!payload.Audience.Equals(CLIENT_ID))
                throw new InvalidJwtException("clientid");
            if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
                throw new InvalidJwtException("issuer");
            if (payload.ExpirationTimeSeconds == null)            
                throw new InvalidJwtException("expirationtimeseconds");
            else
            {
                DateTime now = DateTime.Now.ToUniversalTime();
                DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
                if (now > expiration)
                    throw new InvalidJwtException("expirationtimeseconds");
            }

            MyPayload mypl = new MyPayload ();
            mypl.Email = payload.Email;
            mypl.FirstName = payload.GivenName;
            mypl.LastName = payload.FamilyName;
            mypl.Picture = payload.Picture;

            return mypl;
        }

    }
}