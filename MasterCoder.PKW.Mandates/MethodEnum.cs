//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    enum MethodEnum
    {
        //enumeracja "Unkonow" jest nadmiarowa. Przecież i tak domyślnie używamy metody d'Hondt'a. Poza tym jest literówka w nazwie.
        DHondta, SaintLague, HareNiemeyer
    }
}
