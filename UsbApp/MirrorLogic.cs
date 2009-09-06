using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace UsbApp
{
    [Serializable]
    public enum Action
    {
        [XmlEnum(Name = "Pose")]
        POSE,
        [XmlEnum(Name = "Retire")]
        RETIRE,
        [XmlEnum(Name = "Retourne")]
        RETOURNE,
        [XmlEnum(Name = "RemiseEndroit")]
        REMISE_ENDROIT
    }

    public class MirrorLogic
    {
        public List<ztampStruct> GetZtampList()
        {
            try
            {
                //Essayer de désérialiser un fichier XML de Config des Ztamp, qui retournerait une List de ZtampStruct
                ZtampList aList;
                XmlSerializer s = new XmlSerializer(typeof(ZtampList));
                string ztampPath = MirrorLib.GetZtampListPath();
                List<ztampStruct> ztampStructAsList = new List<ztampStruct>();
                if (File.Exists(ztampPath))
                {
                    TextReader myConfigFile = new StreamReader(ztampPath);
                    aList = (ZtampList)s.Deserialize(myConfigFile);
                    myConfigFile.Close();
                    foreach (ztampStruct anInstance in aList.ZtampInstances)
                        ztampStructAsList.Add(anInstance);
                }
                return ztampStructAsList;
            }
            catch (Exception e)
            {
                Console.WriteLine("**************** DEBUG EX *************");
                Console.WriteLine(e.ToString());
                Console.WriteLine("**************** /DEBUG EX *************");
                return new List<ztampStruct>();
            }
        }

        public void SetZtampList(List<ztampStruct> ztampListInstances)
        {
            ztampStruct[] ztampInstances = new ztampStruct[ztampListInstances.Count];
            int iterator = 0;
            foreach (ztampStruct zStruct in ztampListInstances)
            {
                ztampInstances[iterator++]=zStruct;
            }
            ZtampList serializableList = new ZtampList();
            serializableList.ZtampInstances = ztampInstances;
            XmlSerializer s = new XmlSerializer(typeof(ZtampList));
            if (!Directory.Exists(MirrorLib.GetZtampListFolderPath()))
                Directory.CreateDirectory(MirrorLib.GetZtampListFolderPath());
            TextWriter w = new StreamWriter(MirrorLib.GetZtampListPath(),false);
            s.Serialize(w, serializableList);
            w.Close();
        }

        //Logique ztamp
        public void doMirrorLogic(string ztampID, Action uneAction)
        {
            List<ztampStruct> ztampList = GetZtampList();
            String strFilePath = AppDomain.CurrentDomain.BaseDirectory;
            //Trouver l'action ztamp qui correspond
            foreach (ztampStruct aZtampAction in ztampList)
            {
                if (aZtampAction.ztampID == ztampID && aZtampAction.ztampAction == uneAction)
	            {
		            //traitement du ztamp
                    int it = 0;
		            while(it<aZtampAction.ztampAppCLine.Count)
		            {
                        string cmdLine = aZtampAction.ztampAppCLine[it];
                        string args = aZtampAction.ztampAppArgs[it];
                        try
                        {
                            Process proc = new Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.WorkingDirectory = strFilePath;
                            proc.StartInfo.FileName = cmdLine;
                            proc.StartInfo.Arguments = args;
                            proc.Start();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        it++;
		            }
	            }
	            else
	            {
		            //Introuvable
	            }
            }
        }

        //Logique ztamp
        public List<ztampStruct> getMirrorLogic(string ztampID)
        {
            List<ztampStruct> ztampList = GetZtampList();
            int ztampIterator = 0;
            List<ztampStruct> retourZtampList = new List<ztampStruct>();
            //Trouver les action ztamps qui correspondent
            foreach (ztampStruct aZtampAction in ztampList)
            {
                if (aZtampAction.ztampID == ztampID)
                {
                    retourZtampList.Add(aZtampAction);
                }
            }
            return retourZtampList;
        }
    }

    [XmlRoot("ztampList")]
    public class ZtampList
    {
        private ArrayList myZtampList;

        public ZtampList()
        {
            myZtampList = new ArrayList();
        }

        [XmlElement("ztampInstance")]
        public ztampStruct[] ZtampInstances
        {
            get
            {
                ztampStruct[] ztampInstances = new ztampStruct[myZtampList.Count];
                myZtampList.CopyTo(ztampInstances);
                return ztampInstances;
            }
            set
            {
                if (value == null) return;
                ztampStruct[] ztampInstances = (ztampStruct[])value;
                myZtampList.Clear();
                foreach (ztampStruct ztampInstance in ztampInstances)
                    myZtampList.Add(ztampInstance);
            }
        }

        public int AddZtamp(ztampStruct ztampInstance)
        {
            return myZtampList.Add(ztampInstance);
        }

    }
    
    public class ztampStruct
    {

        private const int nbMaxActions = 10;

        [XmlAttribute("ztampID")]
        public string ztampID;

        [XmlAttribute("ztampName")]
        public string ztampName;

        [XmlAttribute("ztampImg")]
        public string ztampImg;

        [XmlAttribute("ztampAction")]
        public Action ztampAction;

        [XmlElement("ztampAppCLine")]
        public List<string> ztampAppCLine;

        [XmlElement("ztampAppArgs")]
        public List<string> ztampAppArgs;

        public ztampStruct()
        {
        }

        public ztampStruct(string ID, string name, string img, Action action)
        {
            ztampID = ID;
            ztampAction = action;
            ztampName = name;
            ztampImg = img;
            ztampAppCLine = new List<string>();
            ztampAppArgs = new List<string>();
        }

        public void addAction(string actionCLine, string actionArgs)
        {
            if (this.ztampAppCLine == null)
            {
                this.ztampAppCLine = new List<string>();
                this.ztampAppArgs = new List<string>();
            }
            if (this.ztampAppCLine.Count < nbMaxActions)
            {
                this.ztampAppCLine.Add(actionCLine);
                this.ztampAppArgs.Add(actionArgs);
            }
        }

    }
}
