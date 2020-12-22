﻿using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace VFEMech
{
	[HarmonyPatch(typeof(Pawn_NeedsTracker), "ShouldHaveNeed")]
	public static class ShouldHaveNeed_Patch
	{
		public static bool Prefix(Pawn ___pawn, NeedDef nd, ref bool __result)
		{
			if (___pawn is Machine)
			{
				if (nd == VFEMDefOf.VFE_Mechanoids_Power)
				{
					__result = true;
					return false;
				}
			}
			else if (nd == VFEMDefOf.VFE_Mechanoids_Power)
			{
				return false;
			}
			return true;
		}
	}
}