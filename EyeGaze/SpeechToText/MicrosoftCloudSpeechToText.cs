using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using System.Windows;

namespace EyeGaze.SpeechToText
{
    class MicrosoftCloudSpeechToText : InterfaceSpeechToText
    {
        public static async Task<string> RecognizeSpeechAsync()
        {
            var config = SpeechConfig.FromSubscription("4ed9a9d9ba4741f68c455b160ae0d57c", "westeurope");
            //config.SpeechRecognitionLanguage = "es-ES";

            using (var recognizer = new SpeechRecognizer(config))
            {
                var result = await recognizer.RecognizeOnceAsync();
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    return result.Text;
                }
                /* else if (result.Reason == ResultReason.NoMatch)
                 {
                     Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                 }
                 else if (result.Reason == ResultReason.Canceled)
                 {
                     var cancellation = CancellationDetails.FromResult(result);
                     Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                     if (cancellation.Reason == CancellationReason.Error)
                     {
                         Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                         Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                         Console.WriteLine($"CANCELED: Did you update the subscription info?");
                     }
                 }*/
                return "";
            }

        }

        public string listen()
        {
            Task<string> text = RecognizeSpeechAsync();
            return text.Result;
        }
    }
}
