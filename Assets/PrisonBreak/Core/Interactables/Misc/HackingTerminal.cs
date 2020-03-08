﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;


public class HackingTerminal : MonoBehaviour, IInteraction
{
    
    public Canvas TerminalUI;
    public PlayerController PC;
    public TMP_InputField TextInput;
    public TMP_InputField LogText;
    

    [SerializeField]
    private RawImage Img;

    [SerializeField]
    private string UrlQR;
    private List<string> log = new List<string>();
    [SerializeField]
    private Locker LockerDoor;


    private void Awake()
    {
        TerminalUI.enabled = false;
        
    }


    public void Use()
    {
        OpenTerminal();
    }

    void OpenTerminal()
    {
        TerminalUI.enabled = true;
        TextInput.enabled = true;
        PC.DisableInput = true;
    }

    public void TextSubmit()
    {
        // Debug.Log("TextSubmited");
        // Debug.Log(TextInput.text);
        if(log.Count < 20)
        {
            log.Add(TextInput.text + "\n");
            UpdateLog();
        }
        else
        {
            log.Clear();
            log.Add(TextInput.text + "\n");
            LogText.text = "";
            UpdateLog();
        }
        

        switch (TextInput.text)
        {
            default:
            Debug.Log("Invalid Command");
                break;
            case "help":
                log.Add("Commands: \n qr \n meme \n goose\n close \n Pizza \n" + "\n");
                UpdateLog();
                break;
            case "clr":
                log.Clear();
                UpdateLog();

                break;
            case "qr":
                StartCoroutine(RequestTexture());
                break;
            case "meme":
                System.Diagnostics.Process.Start("https://theuselessweb.com/");
                break;
            case "goose":
                System.Diagnostics.Process.Start("https://i.imgur.com/TEryL6h.jpg");
                break;
            case "close":
                CloseTerminal();
                break;
            case "open 5648":
                LockerDoor.Open();
                break;
            case "open":
                log.Add("Invalid Lock Code usage Example: open 1337");
                break;
            case "Pizza":
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=TRgdA9_FsXM");
                break;
        }
        TextInput.text = "";
    }
    private void UpdateLog()
    {
        LogText.text = "";
        foreach (string logItem in log)
        {
            LogText.text += logItem;
        }
        
    }

    public void CloseTerminal()
    {
        PC.DisableInput = false;
        TextInput.enabled = false;
        TerminalUI.enabled = false;
        
    }

    IEnumerator RequestTexture()
    {
        using (UnityWebRequest Tex = UnityWebRequestTexture.GetTexture(UrlQR))
        {
            yield return Tex.SendWebRequest();

            if (Tex.isNetworkError || Tex.isHttpError)
            {
                Debug.Log(Tex.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(Tex);
                Img.texture = texture;
                
            }
        }
    }

}