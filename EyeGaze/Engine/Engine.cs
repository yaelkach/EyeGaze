using EyeGaze.SpeechToText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechToTextAlias = EyeGaze.SpeechToText;

namespace EyeGaze.Engine
{
    class Engine
    {
        static public void Main(String[] args)
        {
            startListen();
        }

        public static void startListen()
        {
            MicrosoftCloudSpeechToText t = new MicrosoftCloudSpeechToText();
            SpeechToTextAlias.SpeechToText speechToText = new SpeechToTextAlias.SpeechToText(t.GetType());
            WireEventHandlers(speechToText);
            speechToText.FindActionFromSpeech();
        }
        private static void WireEventHandlers(SpeechToTextAlias.SpeechToText stt)
        {
            TriggerHandler handler = new TriggerHandler(actionHandler);
            stt.triggerHandler += handler;
        }
        public static void actionHandler(object sender, MessageEvent e)
        {
            Console.WriteLine(e.triggerWord);
        }
    }
}
