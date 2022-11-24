using Verse;

namespace MeteorIncident;

public static class Settings_SliderExtenter
{
    private const float BaseLineHeight = 30f;

    public static void GapGapLine(this Listing_Standard ls, float gapHeight = 12f)
    {
        ls.Gap(gapHeight);
        ls.GapLine(gapHeight);
        ls.Gap(gapHeight);
    }

    public static void MeteorIntervalSlider(this Listing_Standard ls, string label, ref int val, string tooltip = null)
    {
        var rect = ls.GetRect(30f);
        var rect2 = rect.LeftHalf();
        var rect3 = rect.RightHalf();
        if (tooltip != null)
        {
            TooltipHandler.TipRegion(rect3, new TipSignal(tooltip));
        }

        Widgets.Label(rect2, label);
        val = Settings_Sliders.MeteorEventFrequencyHorizontalSlider(rect3, val);
    }
}