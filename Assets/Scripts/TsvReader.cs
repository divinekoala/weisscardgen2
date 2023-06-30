using System;
using System.Collections;
using SimpleFileBrowser;
using UnityEngine;

namespace DefaultNamespace
{
    public class TsvReader : MonoBehaviour
    {
        public void loadFile()
        {
            StartCoroutine(showTsvLoad());
        }

        private IEnumerator showTsvLoad()
        {
            yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.Files, false, null, null,
                "Load file", "Choose");

            if (FileBrowser.Success)
            {
                var file = FileBrowser.Result[0];
                var tsv = FileBrowserHelpers.ReadTextFromFile(file);
                readTsv(tsv);
            }
        }

        public void readTsv(string tsv)
        {
            
            char[] delimiter = new char[] { '\t' };
            var lines = tsv.Split(Environment.NewLine);
            for (int i = 1; i < lines.Length; i++)
            {
                var splitLine = lines[i].Split(delimiter);
                CardValue cv = new CardValue();
                cv.name = splitLine[0];
                cv.cardType = splitLine[1];
                cv.level = int.Parse(splitLine[2]);
                cv.cost = int.Parse(splitLine[3]);
                cv.effect = splitLine[4];
                cv.flavour = splitLine[5];
                cv.jpName = splitLine[6];
                cv.power = int.Parse(splitLine[7]);
                cv.setId = splitLine[8];
                cv.trait1 = splitLine[9];
                cv.trait2 = splitLine[10];
                cv.traitCount = int.Parse(splitLine[11]);
                cv.setColour = splitLine[12];
                cv.soul = int.Parse(splitLine[13]);
                cv.trigger1 = splitLine[14];
                cv.trigger2 = splitLine[15];
                cv.copyright = splitLine[16];
                cv.backupAlarm1 = splitLine[17];
                cv.backupAlarm2 = splitLine[18];
                cv.showEffect = splitLine[19].Equals("true");
                cv.showFlavour = splitLine[20].Equals("true");
                cv.showJpName = splitLine[21].Equals("true");
                cv.colour = splitLine[22];
                GameManager.instance.createCard(cv);
            }
        }

        public string handleEffect(string baseEffect)
        {
            baseEffect.Replace("[AUTO]", "<sprite name=\"Auto\">");
            
            return baseEffect;
        }
    }
}