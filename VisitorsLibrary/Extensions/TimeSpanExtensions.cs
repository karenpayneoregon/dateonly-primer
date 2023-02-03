﻿
namespace VisitorsLibrary.Extensions;

public static class TimeSpanExtensions
{
    public static TimeSpan Elapsed(this TimeSpan startTime, TimeSpan endTimeSpan)
        => new(endTimeSpan.Ticks - startTime.Ticks);

    public static TimeSpan Elapsed(this TimeSpan? startTime, TimeSpan? endTimeSpan)
        => new (endTimeSpan!.Value.Ticks - startTime!.Value.Ticks);

    public static TimeOnly Elapsed(this TimeOnly? startTime, TimeOnly? endTimeSpan)
        => new(endTimeSpan!.Value.Ticks - startTime!.Value.Ticks);

}