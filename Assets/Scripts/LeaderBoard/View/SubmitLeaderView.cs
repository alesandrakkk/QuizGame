using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LeaderBoard.View
{
    public class SubmitLeaderView : MonoBehaviour
    {
        public readonly UnityEvent Submitted = new UnityEvent();
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private Button submitButton;
        [SerializeField] private float recordsTime;
        private ILeaderBoard leaderBoard;
        private readonly StopWatch stopWatch = new StopWatch();

        private void Awake()
        {
            leaderBoard = GetComponent<ILeaderBoard>();
        }

        private void Start()
        {
            submitButton.onClick.AddListener(Submit);
        }

        private async void Submit()
        {
            await leaderBoard.Note(nameInput.text, recordsTime);
            Submitted.Invoke();
        }

        public void StartAndHide()
        {
            stopWatch.Start();
            transform.localScale = Vector3.zero;
        }

        public void StopAndShow()
        {
            stopWatch.Stop();
            transform.localScale = Vector3.one;
        }
    }
}