﻿using System;
using System.ComponentModel;
using FlatSharp.Attributes;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace pkNX.Structures.FlatBuffers;

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class PokeAdd8aArchive : IFlatBufferArchive<PokeAdd8a>
{
    public byte[] Write() => FlatBufferConverter.SerializeFrom(this);

    [FlatBufferItem(0)] public PokeAdd8a[] Table { get; set; } = Array.Empty<PokeAdd8a>();
}

[FlatBufferTable, TypeConverter(typeof(ExpandableObjectConverter))]
public class PokeAdd8a
{
    [FlatBufferItem(00)] public string Field_00 { get; set; } = string.Empty;
    [FlatBufferItem(01)] public int Species { get; set; }
    [FlatBufferItem(02)] public int Form { get; set; }
    [FlatBufferItem(03)] public int Gender { get; set; }
    [FlatBufferItem(04)] public ShinyType8a ShinyLock { get; set; }
    [FlatBufferItem(05)] public int Level { get; set; }
    [FlatBufferItem(06)] public int AbilityRandType { get; set; }
    [FlatBufferItem(07)] public NatureType8a Nature { get; set; }
    [FlatBufferItem(08)] public int Height { get; set; }
    [FlatBufferItem(09)] public int Weight { get; set; }
    [FlatBufferItem(10)] public bool IsOybn { get; set; }
    [FlatBufferItem(11)] public int Move1 { get; set; }
    [FlatBufferItem(12)] public bool Mastered1 { get; set; }
    [FlatBufferItem(13)] public int Move2 { get; set; }
    [FlatBufferItem(14)] public bool Mastered2 { get; set; }
    [FlatBufferItem(15)] public int Move3 { get; set; }
    [FlatBufferItem(16)] public bool Mastered3 { get; set; }
    [FlatBufferItem(17)] public int Move4 { get; set; }
    [FlatBufferItem(18)] public bool Mastered4 { get; set; }
    [FlatBufferItem(19)] public int IV_HP { get; set; }
    [FlatBufferItem(20)] public int IV_ATK { get; set; }
    [FlatBufferItem(21)] public int IV_DEF { get; set; }
    [FlatBufferItem(22)] public int IV_SPA { get; set; }
    [FlatBufferItem(23)] public int IV_SPD { get; set; }
    [FlatBufferItem(24)] public int IV_SPE { get; set; }
    [FlatBufferItem(25)] public int NumPerfectIvs { get; set; }
    [FlatBufferItem(26)] public int GV_HP { get; set; }
    [FlatBufferItem(27)] public int GV_ATK { get; set; }
    [FlatBufferItem(28)] public int GV_DEF { get; set; }
    [FlatBufferItem(29)] public int GV_SPA { get; set; }
    [FlatBufferItem(30)] public int GV_SPD { get; set; }
    [FlatBufferItem(31)] public int GV_SPE { get; set; }
    [FlatBufferItem(32)] public int TryInsertParty { get; set; } // 1 if party attempted, 0 -> straight to box
    [FlatBufferItem(33)] public int Ball { get; set; } // 0 is use default game ball (LAPoke); is set to 37 (Origin) for box legends.

    public string Dump(string[] speciesNames)
    {
        var natureStr = Nature == NatureType8a.Random ? "" : $", Nature = {Nature}";
        var shinyStr = $", Shiny = {ShinyLock}";
        var gvStr = "";
        if (GV_HP != 0)
            gvStr += $", GV_HP = {GV_HP}";
        if (GV_ATK != 0)
            gvStr += $", GV_ATK = {GV_ATK}";
        if (GV_DEF != 0)
            gvStr += $", GV_DEF = {GV_DEF}";
        if (GV_SPA != 0)
            gvStr += $", GV_SPA = {GV_SPA}";
        if (GV_SPD != 0)
            gvStr += $", GV_SPD = {GV_SPD}";
        if (GV_SPE != 0)
            gvStr += $", GV_SPE = {GV_SPE}";

        var hw = $"HeightScalar = {Height:000}, WeightScalar = {Weight:000}";
        var genderStr = Gender == -1 ? "" : $", Gender = {Gender}";
        var iv = NumPerfectIvs == 0 ? "" : $", FlawlessIVCount = {NumPerfectIvs}";
        string comment = $"// {speciesNames[Species]}{(Form == 0 ? "" : $"-{Form}")}";
        return $"new({Species:000},{Form:000},{Level:00}) {{ Gift = true, {hw}{shinyStr}{genderStr}{natureStr}{iv}{gvStr} }}, {comment}";
    }
}
