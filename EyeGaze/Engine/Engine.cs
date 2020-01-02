using EyeGaze.SpeechToText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechToTextAlias = EyeGaze.SpeechToText;
using eyeGaze = EyeGaze.EyeGaze.EyeGaze;
using System.Windows;
using EyeGaze.OCR;
using System.Threading;

namespace EyeGaze.Engine
{
    class Engine
    {
        public Engine() { }

        public void startListen()
        {
            MicrosoftCloudSpeechToText t = new MicrosoftCloudSpeechToText();
            SpeechToTextAlias.SpeechToText speechToText = new SpeechToTextAlias.SpeechToText(t.GetType());
            WireEventHandlers(speechToText);
            speechToText.FindActionFromSpeech();
        }
        private void WireEventHandlers(SpeechToTextAlias.SpeechToText stt)
        {
            TriggerHandler handler = new TriggerHandler(actionHandler);
            stt.triggerHandler += handler;
        }
        public void actionHandler(object sender, MessageEvent e)
        {
            Point p = eyeGaze.GetCursorPosition();
            MessageBox.Show(p.X + "and" + p.Y);
            TesseractOCR ocr = new TesseractOCR();
        }

    }
}
