using Demo.Presentation.Settings;
using Demo.Presentation.Utilities;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Demo.Presentation.Helpers
{
    public class SmsService(IOptions<SmsSettings> _options) : ISmsService
    {
        public MessageResource SendSms(SmsMessage smsMessage)
        {

            TwilioClient.Init(_options.Value.AccountSID, _options.Value.AuthToken);

            var Message = MessageResource.Create(
                body: smsMessage.Body,
                from: new Twilio.Types.PhoneNumber(_options.Value.TwilioPhoneNumber),
                to:smsMessage.PhoneNumber
                );
             


          return( Message );
           
        }
    }
}
