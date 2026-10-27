using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
public class MeterConverter : ConverterBase {
    public override bool IsMyUnit(string name) =>
        name.Equals("meter", StringComparison.CurrentCultureIgnoreCase) || name == UnitName;

    protected override double Ratio => 1;
    public override string UnitName => "メートル";
}

public class FeetConverter : ConverterBase {
    public override bool IsMyUnit(string name) =>
        name.Equals("feet", StringComparison.CurrentCultureIgnoreCase) || name == UnitName;

    protected override double Ratio => 0.3048;
    public override string UnitName => "フィート";
}

public class InchConverter : ConverterBase {
    public override bool IsMyUnit(string name) =>
        name.Equals("inch", StringComparison.CurrentCultureIgnoreCase) || name == UnitName;

    protected override double Ratio => 0.0254;
    public override string UnitName => "インチ";
}

public class YardConverter : ConverterBase {
    public override bool IsMyUnit(string name) =>
        name.Equals("yard", StringComparison.CurrentCultureIgnoreCase) || name == UnitName;

    protected override double Ratio => 0.9144;
    public override string UnitName => "ヤード";
}
