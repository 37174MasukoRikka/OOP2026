using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
public class DistanceConverter {
    public ConverterBase From { get; init; }
    public ConverterBase To { get; init; }

    //コンストラクタ
    public DistanceConverter(ConverterBase from, ConverterBase to) {
        From = from;
        To = to;
    }
    public double Convert(double value) {
        var meter = From.ToMeter(value);   //変換元の単位からメートルへ変換
        return To.FromMeter(meter);        //メートルから変換先の単位へ変換
    }
}


