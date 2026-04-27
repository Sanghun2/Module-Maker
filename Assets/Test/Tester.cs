using System;
using System.Collections.Generic;
using BilliotGames;
using UnityEngine;

public class Tester : Singleton<Tester>
{
    protected override void Awake() {
        base.Awake();

        var sound = new SoundManager();
        sound.SetClipLoader(new ResourceClipLoader("Sound"));
        sound.InitClips("Sound");
    }
}
