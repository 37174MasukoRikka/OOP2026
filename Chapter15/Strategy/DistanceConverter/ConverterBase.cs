using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
//抽象クラス
public abstract class ConverterBase {
    //引数で与えられた単位が自分のものか判断
    public abstract bool IsMyUnit(string name);

    //メートルとの比率(この比率を掛けるとメートルに変換でできる)
    protected abstract double Ratio { get; }

    //距離の単位名(例えば、"メートル"、"フィート"など)
    public abstract string UnitName { get; }

    //メートルからの変換
    public double FromMeter(double meter) => meter / Ratio;

    //メートルへの変換
    public double ToMeter(double feet) => feet * Ratio;

}

