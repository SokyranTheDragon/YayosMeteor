﻿using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace MeteorIncident;

public class IncidentWorker_MeteorStormCondition : IncidentWorker
{
    protected override bool TryExecuteWorker(IncidentParms parms)
    {
        GameCondition_MeteorStorm.nextMeteorTicks =
            Find.TickManager.TicksGame + GameCondition_MeteorStorm.nextMeteorTicksReset;
        var target = (Map)parms.target;
        var duration = Mathf.RoundToInt(def.durationDays.RandomInRange * 60000f);
        var conditionMeteor =
            (GameCondition_MeteorStorm)GameConditionMaker.MakeCondition(GameConditionDef.Named("MeteorStorm"),
                duration);
        target.gameConditionManager.RegisterCondition(conditionMeteor);
        var tmp_lookTargets = new LookTargets();
        var ar_pawn_all = target.mapPawns.FreeColonists.ToList();
        foreach (var pawn in ar_pawn_all)
        {
            tmp_lookTargets.targets.Add(new TargetInfo(pawn));
        }


        Find.LetterStack.ReceiveLetter("Meteo_letterTitle".Translate(),
            "Meteo_letterDesc".Translate(),
            LetterDefOf.ThreatBig,
            tmp_lookTargets
        );
        return true;
    }
}