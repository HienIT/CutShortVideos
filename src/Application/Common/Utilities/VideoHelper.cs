using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Utilities;
public static class VideoHelper
{
    public static (TimeSpan, string) GetVideoInfo(string videoPath)
    {
        // Lấy thông tin thẻ
        var tag = TagLib.File.Create(videoPath);

        // Lấy thời gian
        var duration = tag.Properties.Duration;

        // Lấy độ phân giải
        var width = tag.Properties.VideoWidth;
        var height = tag.Properties.VideoHeight;

        return (duration, $"{width}x{height}");
    }
}
