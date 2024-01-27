using BlazorPopper.Utils;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BlazorPopper;

public class Options
{
    [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
    [JsonPropertyName("placement")]
    public Placement Placement { get; set; } = Placement.Bottom;

    [JsonConverter(typeof(EnumDescriptionConverter<Strategy>))]
    [JsonPropertyName("strategy")]
    public Strategy Strategy { get; set; } = Strategy.Absolute;

}

public enum Placement
{
    [Description("auto")] Auto,
    [Description("auto-start")] AutoStart,
    [Description("auto-end")] AutoEnd,
    [Description("top")] Top,
    [Description("top-start")] TopStart,
    [Description("top-end")] TopEnd,
    [Description("bottom")] Bottom,
    [Description("bottom-start")] BottomStart,
    [Description("bottom-end")] BottomEnd,
    [Description("right")] Right,
    [Description("right-start")] RightStart,
    [Description("right-end")] RightEnd,
    [Description("left")] Left,
    [Description("left-start")] LeftStart,
    [Description("left-end")] LeftEnd
}

public enum Strategy
{
    [Description("absolute")] Absolute,
    [Description("fixed")] Fixed
}