using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class EW_RecordTransform : MonoBehaviour {

    public GameObject recordObject;
    public GameObject playbackObject;
    public string path;
    public string filename;
    public bool record;
    public bool playback;

    List<Vector3> position;
    List<Quaternion> rotation;
    List<float> time;
    int timeIndex = 0;
    float currentTime;

    string readText;

	void Start () {

        SceneManager.activeSceneChanged += saveScene;

        position = new List<Vector3>();
        rotation = new List<Quaternion>();
        time = new List<float>();

        if (!record && playback) {
            StreamReader reader = new StreamReader(path+filename);
            readText = reader.ReadToEnd();
            reader.Close();
            string[] lists = readText.Split('|');
            string[] posList = lists[0].Split('>');
            string[] rotList = lists[1].Split('>');
            for (int i = 0; i < posList.Length; i++) {
                if (posList[i].Length > 0) {
                    string[] vec = posList[i].Split(',');
                    Vector3 p = new Vector3(float.Parse(vec[0]), float.Parse(vec[1]), float.Parse(vec[2]));
                    position.Add(p);
                }
            }
            for (int i = 0; i < rotList.Length; i++) {
                if (rotList[i].Length > 0) {
                    string[] quat = rotList[i].Split(',');
                    Quaternion q = new Quaternion(float.Parse(quat[0]), float.Parse(quat[1]), float.Parse(quat[2]), float.Parse(quat[3]));
                    rotation.Add(q);
                }
            }
            string[] flt = lists[2].Split(',');
            for (int i = 0; i < flt.Length-1; i++) {
                if(flt[i].Length>0)
                    time.Add(float.Parse(flt[i]));
            }
        }
    }
	
	void Update () {
        if (record && Time.timeSinceLevelLoad>0) {
            position.Add(recordObject.transform.position);
            rotation.Add(recordObject.transform.rotation);
            time.Add(Time.timeSinceLevelLoad);
        }
        else if (playback && timeIndex < time.Count-1) {
            float thisTime = Time.timeSinceLevelLoad;
            while (time[timeIndex] < thisTime) {
                timeIndex++;
            }
            currentTime =(time[timeIndex-1]-Time.timeSinceLevelLoad) / (time[timeIndex-1]-time[timeIndex]);
            playbackObject.transform.position = Vector3.Lerp(position[timeIndex - 1], position[timeIndex], currentTime);
            playbackObject.transform.rotation = Quaternion.Lerp(rotation[timeIndex - 1], rotation[timeIndex], currentTime);
        }
    }

    void OnApplicationQuit() {
        saveScene();
    }

    void saveScene(Scene a, Scene b) {
        saveScene();
    }

    void saveScene() {
        if (record) {
            string pos = "";
            string rot = "";
            string tm = "";
            string all = "";

            for (int i = 0; i < position.Count; i++) {
                pos += position[i].x + "," + position[i].y + "," + position[i].z + ">";
            }
            for (int i = 0; i < rotation.Count; i++) {
                rot += rotation[i].x + "," + rotation[i].y + "," + rotation[i].z + "," + rotation[i].w + ">";
            }
            for (int i = 0; i < time.Count; i++) {
                tm += time[i] + ",";
            }

            all += pos + "|" + rot + "|" + tm;

            StreamWriter writer = new StreamWriter(path + filename, true);
            writer.WriteLine(all);
            writer.Close();
        }
    }
}
