using EyeGaze.SpeechToText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechToTextAlias = EyeGaze.SpeechToText;
using eyeGaze = EyeGaze.EyeTracking.EyeGaze;
using System.Windows;
using EyeGaze.OCR;
using System.Threading;
using asprise_ocr_api;
using System.Xml;
using Point = System.Drawing.Point;
using EyeGaze.TextEditor;

namespace EyeGaze.Engine
{
    class EngineMain
    {
        public EngineMain() { }
        private AspOCR ocr;
        private WordTextEditor word;
        public void startListen()
        {
           // MicrosoftCloudSpeechToText t = new MicrosoftCloudSpeechToText();
            ocr = new AspOCR();
            //SpeechToTextAlias.SpeechToText speechToText = new SpeechToTextAlias.SpeechToText(t.GetType());
            //WireEventHandlers(speechToText);
            word = new WordTextEditor();
            
           // speechToText.FindActionFromSpeech();

            ChangeWords();
            ChangeWords();

        
        }
        private void WireEventHandlers(SpeechToTextAlias.SpeechToText stt)
        {
            TriggerHandler handler = new TriggerHandler(actionHandler);
            stt.triggerHandler += handler;
        }
        public void actionHandler(object sender, MessageEvent e)
        {
            if (e.triggerWord.Equals("Fix"))
            {
                System.Windows.Point p = eyeGaze.GetCursorPosition();
                MessageBox.Show(p.X + "and" + p.Y);
                Dictionary<Point, string> wordWithCoordinates = ocr.getWordWithCoordinates();
                List<Point> coordinates = new List<Point>(wordWithCoordinates.Keys);
                Dictionary<Point, double> distanceFromCoordinate = findDistanceFromCoordinate(177, 480, coordinates);
                List<KeyValuePair<Point, double>> sortedPoints = sortByDistance(distanceFromCoordinate);

                List<KeyValuePair<Point, string>> sortedValues = sortValues(wordWithCoordinates, sortedPoints);
                word.setSortedValues(sortedValues);
                word.openWord();

            }
        }
        public void ChangeWords()
        {
                System.Windows.Point p = eyeGaze.GetCursorPosition();
                //MessageBox.Show(p.X + "and" + p.Y);
                Dictionary<Point, string> wordWithCoordinates = ocr.getWordWithCoordinates();
                List<Point> coordinates = new List<Point>(wordWithCoordinates.Keys);
                Dictionary<Point, double> distanceFromCoordinate = findDistanceFromCoordinate(177, 480, coordinates);
                List<KeyValuePair<Point, double>> sortedPoints = sortByDistance(distanceFromCoordinate);

                List<KeyValuePair<Point, string>> sortedValues = sortValues(wordWithCoordinates, sortedPoints);
                word.setSortedValues(sortedValues);
                word.openWord();

            
        }


        public Dictionary<Point, double> findDistanceFromCoordinate(int x, int y, List<Point> coordinates)
        {
            Dictionary<Point, double> result = new Dictionary<Point, double>();
            foreach (Point point in coordinates)
            {
                double distance = Math.Sqrt(Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2));
                if (distance < 300)
                {
                    result.Add(point, distance);
                }
            }
            return result;
        }

        public List<KeyValuePair<Point, double>> sortByDistance(Dictionary<Point, double> coordinatesDistance)
        {
            List<KeyValuePair<Point, double>> myList = coordinatesDistance.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return myList;
        }

        private List<KeyValuePair<Point, string>> sortValues(Dictionary<Point, string> coordinatesWithWords,
            List<KeyValuePair<Point, double>> sortedPoints)
        {
            List<KeyValuePair<Point, string>> sortedValues = new List<KeyValuePair<Point, string>>();
            foreach (KeyValuePair<Point, double> point in sortedPoints)
            {
                string word;
                coordinatesWithWords.TryGetValue(point.Key, out word);
                KeyValuePair<Point, string> pair = new KeyValuePair<Point, string>(point.Key, word);
                sortedValues.Add(pair);
            }
            return sortedValues;
        }

    }
}
