using ScpiLib.attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScpiLib.Command
{
    public enum EScpiCmd
    {
        [Display(Name = "abor")]
        Abort,
        [Display(Name = "appl")]
        Apply,
        [Display(Name = "displ")]
        Display,
        Menu,
        [SquareBracketItem]
        Name,
        [Display(Name ="wind")]
        [SquareBracketItem]
        Window,
        Text,
        [Display(Name ="cle")]
        Clear,
        [SquareBracketItem]
        Data,
        [Display(Name ="blin")]
        Blink,
        [Display(Name ="init")]
        Initiate,
        [Display(Name ="imm")]
        [SquareBracketItem]
        Immediate,
        [Display(Name ="meas")]
        Measure,
        [Display(Name ="scal")]
        [SquareBracketItem]
        Scalar,
        [Display(Name ="curr")]
        Current,
        [Display(Name ="volt")]
        Voltage,
        [Display(Name ="pow")]
        Power,
        [SquareBracketItem]
        Dc,
        [Display(Name = "outp")]
        Output,
        [Display(Name ="del")]
        Delay,
        On,
        Off,
        Mode,
        [Display(Name ="stat")]
        [SquareBracketItem]
        State,
        [Display(Name ="trig")]
        Triggered,
        [Display(Name ="prot")]
        Protection,
        [Display(Name ="trip")]
        Tripped,
        [Display(Name ="stat")]
        Status,
        [Display(Name ="oper")]
        Operation,
        [Display(Name ="even")]
        Event,
        [Display(Name ="cond")]
        Condition,
        [Display(Name = "enab")]
        Enable,
        [Display(Name ="ptr")]
        Ptransition,
        [Display(Name="ntr")]
        Ntransition,
        [Display(Name ="ques")]
        Questionable,
        [Display(Name="pres")]
        Preset,
        [Display(Name ="sour")]
        [SquareBracketItem]
        Source,
        [Display(Name="lev")]
        [SquareBracketItem]
        Level,
        [Display(Name="ampl")]
        [SquareBracketItem]
        Ampliude,
        Slew,
        [Display(Name ="ris")]
        Rising,
        [Display(Name ="fall")]
        Falling,
        [Display(Name ="res")]
        Resistance,
        [Display(Name="trig")]
        Trigger,
        [Display(Name ="tran")]
        Transient,
        [Display(Name="syst")]
        System,
        [Display(Name="conf")]
        Configure,
        [Display(Name="beep")]
        Beeper,
        [Display(Name ="ble")]
        Bleeder,
        [Display(Name="btr")]
        Breip,
        [Display(Name ="cont")]
        Control,
        [Display(Name ="Msl")]
        Mslave,
        [Display(Name ="ext")]
        External,
        Pon,
        [Display(Name ="comm")]
        Communicate,
        Gpib,
        [SquareBracketItem]
        Self,
        [Display(Name ="addr")]
        Address,
        Lan,
        [Display(Name="ipad")]
        Ipaddress,
        [Display(Name="gate")]
        Gateway,
        [Display(Name ="smas")]
        Smask,
        [Display(Name="mac")]
        Mac,
        [Display(Name="dhcp")]
        Dhcp,
        [Display(Name="dns")]
        Dns,
        usb,
        [Display(Name ="fron")]
        Front,
        Rear,
        [Display(Name="err")]
        Error,
        Klock,
        [Display(Name="vers")]
        Version
    }
}
