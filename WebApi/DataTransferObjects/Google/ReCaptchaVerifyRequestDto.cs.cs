﻿using System.Collections.Generic;

namespace Eadent.Common.WebApi.DataTransferObjects.Google
{
    public class ReCaptchaVerifyRequestDto : List<KeyValuePair<string, string>>
    {
        public string secret
        {
            set
            {
                Add(new KeyValuePair<string, string>("secret", value));
            }
        }

        public string response
        {
            set
            {
                Add(new KeyValuePair<string, string>("response", value));
            }
        }

        public string remoteip
        {
            set
            {
                Add(new KeyValuePair<string, string>("remoteip", value));
            }
        }
    }
}
