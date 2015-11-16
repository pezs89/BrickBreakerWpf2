using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace BrickBreaker_2015.Model
{
    public class Options
    {
        public string Resolution { get; set; }
        public string LeftMove { get; set; }
        public string PauseButton { get; set; }
        public string FireButton { get; set; }
        public bool IsMouseEnabled { get; set; }
        public string RightMove { get; set; }
        public bool IsKeyBoardEnabled { get; set; }
        public bool IsSoundEnabled { get; set; }
        public string retVal { get; set; }

        public bool IsChanged = false;

        

        public Options()
        {
            LoadFromXml();
        }

        public void LoadFromXml()
        {
            if (!File.Exists("OptionsSettings.xml"))
            {
                XElement mouseElement = new XElement("mouse", "true");
                XElement keyboardElement = new XElement("keyboard", "true");
                XElement soundElement = new XElement("sound", "true");
                XElement resolutionElement = new XElement("resolution", "800x600");
                XElement leftkeyElement = new XElement("leftkey", "Left");
                XElement rightkeyElement = new XElement("rightkey", "Right");
                XElement firekeyElement = new XElement("firekey", "Space");
                XElement pausekeyElement = new XElement("pausekey", "P");
                XElement difficultyElement = new XElement("difficulty", "1");
                XElement mapElement = new XElement("map", "1");
                XAttribute newAttribute = new XAttribute("id", 1);
                XElement newElements = new XElement("option", newAttribute, mouseElement, keyboardElement, soundElement, resolutionElement, leftkeyElement, rightkeyElement, firekeyElement, pausekeyElement, difficultyElement, mapElement);
                XElement newOptions = new XElement("Options", newElements);
                XDocument newDocument = new XDocument(newOptions);
                newDocument.Save("OptionsSettings.xml");
            }
            // If the file doesn't exist, then create a new.

            XDocument settingsFromXml = XDocument.Load("OptionsSettings.xml");
            var readDataFromXml = settingsFromXml.Descendants("option");
            var fromXml = from x in readDataFromXml
                          select x;
            // Load the values stored in the xml.
            foreach (var oneElement in fromXml)
            {
                Resolution = (string)oneElement.Element("resolution");
                LeftMove = (string)oneElement.Element("leftkey");
                PauseButton = (string)oneElement.Element("pausekey");
                FireButton = (string)oneElement.Element("firekey");
                IsMouseEnabled = (bool)oneElement.Element("mouse");
                RightMove = (string)oneElement.Element("rightkey");
                IsKeyBoardEnabled = (bool)oneElement.Element("keyboard");
                IsSoundEnabled = (bool)oneElement.Element("sound");
            }
            
        }

        public void SaveToXml(string Resolution, string LeftMove, string RightMove, string PauseButton, string FireButton, bool IsMouseEnabled, bool IsKeyBoardEnabled, bool IsSoundEnabled)
        {
            XDocument settingsFromXml = XDocument.Load("OptionsSettings.xml");
            var readDataFromXml = settingsFromXml.Descendants("option");
            var fromXml = from x in readDataFromXml
                          select x;
            // Load the values stored in the xml.
            foreach (var oneElement in fromXml)
            {
                if (fromXml.Single().Element("leftkey").Value != LeftMove)
                {
                    fromXml.Single().Element("leftkey").Value = LeftMove;
                    IsChanged = true;
                }
                if (fromXml.Single().Element("rightkey").Value != RightMove)
                {
                    fromXml.Single().Element("rightkey").Value = RightMove;
                    IsChanged = true;
                }
                if (fromXml.Single().Element("pausekey").Value != PauseButton)
                {
                    fromXml.Single().Element("pausekey").Value = PauseButton;
                    IsChanged = true;
                }
                if (fromXml.Single().Element("resolution").Value != Resolution)
                {
                    fromXml.Single().Element("resolution").Value = Resolution;
                    IsChanged = true;
                }
                if (fromXml.Single().Element("firekey").Value != FireButton)
                {
                    fromXml.Single().Element("firekey").Value = FireButton;
                    IsChanged = true;
                }
                if (fromXml.Single().Element("mouse").Value != IsMouseEnabled.ToString())
                {
                    fromXml.Single().Element("mouse").Value = IsMouseEnabled.ToString();
                    IsChanged = true;
                }
                if (fromXml.Single().Element("keyboard").Value != IsKeyBoardEnabled.ToString())
                {
                    fromXml.Single().Element("keyboard").Value = IsKeyBoardEnabled.ToString();
                    IsChanged = true;
                }
                if (fromXml.Single().Element("sound").Value != IsSoundEnabled.ToString())
                {
                    fromXml.Single().Element("sound").Value = IsSoundEnabled.ToString();
                    IsChanged = true;
                }
                settingsFromXml.Save("OptionsSettings.xml");
            }
        }

        public bool Check(string inputKey)
        {
            if (!string.IsNullOrEmpty(inputKey))
            {
                if (inputKey == PauseButton || inputKey == RightMove || inputKey == FireButton)
                {
                    return false;
                }
                else if (inputKey == LeftMove || inputKey == PauseButton || inputKey == FireButton)
                {
                    return false;
                }
                else if (inputKey == LeftMove || inputKey == FireButton || inputKey == RightMove)
                {
                    return false;
                }
                else if (inputKey == LeftMove || inputKey == RightMove || inputKey == PauseButton)
                {
                    return false;
                }
            } return true;            
        }

        public string SpecKeys(Key inputKey)
        {
            switch (inputKey)
            {
                case Key.Left:
                    retVal = "Left";
                    break;
                case Key.Right:
                    retVal = "Right";
                    break;
                case Key.Up:
                    retVal = "Up";
                    break;
                case Key.Down:
                    retVal = "Down";
                    break;
                case Key.Enter:
                    // Also known as Key.Return.
                    retVal = "Enter";
                    break;
                case Key.Space:
                    retVal = "Space";
                    break;
                case Key.LeftShift:
                    retVal = "LeftShift";
                    break;
                case Key.RightShift:
                    retVal = "RightShift";
                    break;
                case Key.LeftCtrl:
                    retVal = "LeftCtrl";
                    break;
                case Key.RightCtrl:
                    retVal = "RightCtrl";
                    break;
                case Key.LeftAlt:
                    retVal = "LeftAlt";
                    break;
                case Key.RightAlt:
                    retVal = "RightAlt";
                    break;
                case Key.Tab:
                    retVal = "Tab";
                    break;
                case Key.F1:
                    retVal = "F1";
                    break;
                case Key.F2:
                    retVal = "F2";
                    break;
                case Key.F3:
                    retVal = "F3";
                    break;
                case Key.F4:
                    retVal = "F4";
                    break;
                case Key.F5:
                    retVal = "F5";
                    break;
                case Key.F6:
                    retVal = "F6";
                    break;
                case Key.F7:
                    retVal = "F7";
                    break;
                case Key.F8:
                    retVal = "F8";
                    break;
                case Key.F9:
                    retVal = "F9";
                    break;
                case Key.F10:
                    retVal = "F10";
                    break;
                case Key.F11:
                    retVal = "F11";
                    break;
                case Key.F12:
                    retVal = "F12";
                    break;
                case Key.PageUp:
                    retVal = "PageUp";
                    break;
                case Key.PageDown:
                    retVal = "PageDown";
                    break;
                case Key.Home:
                    retVal = "Home";
                    break;
                case Key.Insert:
                    retVal = "Insert";
                    break;
                case Key.End:
                    retVal = "End";
                    break;
                case Key.Delete:
                    retVal = "Delete";
                    break;
                default:
                    retVal = inputKey.ToString();
                    break;
            } return retVal;
        }

    }
}
