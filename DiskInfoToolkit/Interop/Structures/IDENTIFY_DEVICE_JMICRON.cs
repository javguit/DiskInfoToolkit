using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct IDENTIFY_DEVICE_JMICRON
    {
        public IDENTIFY_DEVICE_JMICRON()
        {
            Retired1                           = new ushort[ 2];
            SerialNumber                       = new byte[20];
            FirmwareRev                        = new byte[ 8];
            Model                              = new byte[40];
            Obsolute6                          = new ushort[ 5];
            Reserved2                          = new ushort[ 6];
            Reserved4                          = new ushort[ 4];
            Reserved6                          = new ushort[ 8];
            VendorSpecific                     = new ushort[31];
            ReservedForCompactFlashAssociation = new ushort[ 7];
            AdditionalProductIdentifier        = new ushort[ 4];
            Reserved7                          = new ushort[ 2];
            CurrentMediaSerialNo               = new byte[60];
            ReservedForCeAta1                  = new ushort[ 2];
            ReservedForCeAta2                  = new ushort[10];
            Reserved10                         = new ushort[19];
        }

        public ushort GeneralConfiguration;                  //0
        public ushort LogicalCylinders;                      //1	Obsolete
        public ushort SpecificConfiguration;                 //2
        public ushort LogicalHeads;                          //3 Obsolete
        public ushort[] Retired1;                           //4-5
        public ushort LogicalSectors;                            //6 Obsolete
        public uint ReservedForCompactFlash;              //7-8
        public ushort Retired2;                              //9
        public byte[] SerialNumber;                      //10-19
        public ushort Retired3;                              //20
        public ushort BufferSize;                                //21 Obsolete
        public ushort Obsolute4;                             //22
        public byte[] FirmwareRev;                            //23-26
        public byte[] Model;                             //27-46
        public ushort MaxNumPerInterupt;                     //47
        public ushort Reserved1;                             //48
        public ushort Capabilities1;                         //49
        public ushort Capabilities2;                         //50
        public uint Obsolute5;                                //51-52
        public ushort Field88and7064;                            //53
        public ushort[] Obsolute6;                          //54-58
        public ushort MultSectorStuff;                       //59
        public uint TotalAddressableSectors;              //60-61
        public ushort Obsolute7;                             //62
        public ushort MultiWordDma;                          //63
        public ushort PioMode;                               //64
        public ushort MinMultiwordDmaCycleTime;              //65
        public ushort RecommendedMultiwordDmaCycleTime;      //66
        public ushort MinPioCycleTimewoFlowCtrl;             //67
        public ushort MinPioCycleTimeWithFlowCtrl;           //68
        public ushort[] Reserved2;                          //69-74
        public ushort QueueDepth;                                //75
        public ushort SerialAtaCapabilities;                 //76
        public ushort SerialAtaAdditionalCapabilities;       //77
        public ushort SerialAtaFeaturesSupported;                //78
        public ushort SerialAtaFeaturesEnabled;              //79
        public ushort MajorVersion;                          //80
        public ushort MinorVersion;                          //81
        public ushort CommandSetSupported1;                  //82
        public ushort CommandSetSupported2;                  //83
        public ushort CommandSetSupported3;                  //84
        public ushort CommandSetEnabled1;                        //85
        public ushort CommandSetEnabled2;                        //86
        public ushort CommandSetDefault;                     //87
        public ushort UltraDmaMode;                          //88
        public ushort TimeReqForSecurityErase;               //89
        public ushort TimeReqForEnhancedSecure;              //90
        public ushort CurrentPowerManagement;                    //91
        public ushort MasterPasswordRevision;                    //92
        public ushort HardwareResetResult;                   //93
        public ushort AcoustricManagement;                   //94
        public ushort StreamMinRequestSize;                  //95
        public ushort StreamingTimeDma;                      //96
        public ushort StreamingAccessLatency;                    //97
        public uint StreamingPerformance;                 //98-99
        public ulong MaxUserLba;                               //100-103
        public ushort StremingTimePio;                       //104
        public ushort Reserved3;                             //105
        public ushort SectorSize;                                //106
        public ushort InterSeekDelay;                            //107
        public ushort IeeeOui;                               //108
        public ushort UniqueId3;                             //109
        public ushort UniqueId2;                             //110
        public ushort UniqueId1;                             //111
        public ushort[] Reserved4;                          //112-115
        public ushort Reserved5;                             //116
        public uint WordsPerLogicalSector;                    //117-118
        public ushort[] Reserved6;                          //119-126
        public ushort RemovableMediaStatus;                  //127
        public ushort SecurityStatus;                            //128
        public ushort[] VendorSpecific;                        //129-159
        public ushort CfaPowerMode1;                         //160
        public ushort[] ReservedForCompactFlashAssociation; //161-167
        public ushort DeviceNominalFormFactor;               //168
        public ushort DataSetManagement;                     //169
        public ushort[] AdditionalProductIdentifier;            //170-173
        public ushort[] Reserved7;                          //174-175
        public byte[] CurrentMediaSerialNo;              //176-205
        public ushort SctCommandTransport;                   //206
        public ushort[] ReservedForCeAta1;                  //207-208
        public ushort AlignmentOfLogicalBlocks;              //209
        public uint WriteReadVerifySectorCountMode3;      //210-211
        public uint WriteReadVerifySectorCountMode2;      //212-213
        public ushort NvCacheCapabilities;                   //214
        public uint NvCacheSizeLogicalBlocks;             //215-216
        public ushort NominalMediaRotationRate;              //217
        public ushort Reserved8;                             //218
        public ushort NvCacheOptions1;                       //219
        public ushort NvCacheOptions2;                       //220
        public ushort Reserved9;                             //221
        public ushort TransportMajorVersionNumber;           //222
        public ushort TransportMinorVersionNumber;           //223
        public ushort[] ReservedForCeAta2;                 //224-233
        public ushort MinimumBlocksPerDownloadMicrocode;     //234
        public ushort MaximumBlocksPerDownloadMicrocode;     //235
        public ushort[] Reserved10;                            //236-254
        public ushort IntegrityWord;							//255
    }
}
