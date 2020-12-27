/******************************************************************************
 * $Header$
 * $DateTime$
 *
 *
 ******************************************************************************
 *
 * Copyright (c) 2014-2016 Qualcomm Technologies, Inc.
 * All rights reserved.
 * Qualcomm Technologies, Inc. Confidential and Proprietary.
 *
 ******************************************************************************
 */
using System;
using System.Runtime.InteropServices;

namespace QLIBHelper
{
    public sealed class PhoneConstants
    {
        private PhoneConstants() { }

        public const int AutoSearchComPort = 0xFFFF;
        public const int PhoneConnectTimeOutInSec = 10;
        public const int MaxDiagPktSize = 4096;
        public const int DefaultRespSize = 2048;
        public const int RespSize = 10000;
        public const int NumberOfDemodBitsInOneLogPacket = 20;
        public const int MaxLogMsgSize = 4096;

        public const int LOG_NOTHING = 0x0000;   //!<' log nothing
        public const int LOG_C_HIGH_LEVEL_START = 0x0200;   //!<' High level C function start, indicates the begining of a high level C function, which
        //!<' calls other low level C functions internal to the library
        public const int LOG_C_HIGH_LEVEL_STOP = 0x4000;   //!<' High level C function stop
        public const int LOG_IO = 0x0001;   //!<' data IO (data bytes)
        public const int LOG_FN = 0x0002;   //!<' function calls with parameters
        public const int LOG_RET = 0x0004;   //!<' function return data
        public const int LOG_INF = 0x0008;   //!<' general information (nice to know)--do not use this one, as
        //!<' this space needs to be reserved for async messages
        public const int LOG_ASYNC = 0x0008;   //!<' asynchronous messages
        public const int LOG_ERR = 0x0010;   //!<' critical error information
        public const int LOG_IO_AHDLC = 0x0020;   //!<' HDLC IO tracing (data bytes)
        public const int LOG_FN_AHDLC = 0x0040;   //!<' HDLC layer function calls
        public const int LOG_RET_AHDLC = 0x0080;   //!<' HDLC function return data
        public const int LOG_INF_AHDLC = 0x0100;   //!<' HDLC general information
        public const int LOG_ERR_AHDLC = LOG_INF_AHDLC;   //!<' HDLC Error info merged with LOG_INF_AHDLC, to free up the log bit
        public const int LOG_IO_DEV = 0x0400;   //!<' device IO tracing (data bytes)
        public const int LOG_FN_DEV = 0x0800;   //!<' device layer function calls
        public const int LOG_RET_DEV = 0x1000;   //!<' device function return data
        public const int LOG_INF_DEV = 0x2000;   //!<' device general information
        public const int LOG_ERR_DEV = LOG_INF_DEV;      //!<' device error information, merged with LOG_INF_DEV to free up the log bit
        public const int LOG_DEFAULT = (LOG_C_HIGH_LEVEL_START | LOG_C_HIGH_LEVEL_STOP | LOG_FN | LOG_IO | LOG_RET | LOG_ERR | LOG_ASYNC); //!<'  default settings
        public const int LOG_ALL = 0xFFFF;   //!<' everything
    }

    public enum nv_items_enum_type
    {

        /*-------------------------------------------------------------------------*/

        /* Electronic Serial Number.                                               */

        NV_ESN_I = 0,            /* Electronic Serial Number                     */
        NV_ESN_CHKSUM_I,         /* Electronic Serial Number checksum            */

        /*-------------------------------------------------------------------------*/

        /* NV version numbers.                                                     */

        NV_VERNO_MAJ_I,          /* NV Major version number                      */
        NV_VERNO_MIN_I,          /* NV Minor version number                      */

        /*-------------------------------------------------------------------------*/

        /* Permanent physical station configuration parameters.                    */

        NV_SCM_I,                /* SCMp                                         */
        NV_SLOT_CYCLE_INDEX_I,   /* Slot cycle index                             */
        NV_MOB_CAI_REV_I,        /* Mobile CAI revision number                   */
        NV_MOB_FIRM_REV_I,       /* Mobile firmware revision number              */
        NV_MOB_MODEL_I,          /* Mobile model                                 */
        NV_CONFIG_CHKSUM_I,      /* Checksum of physical configuration parameters*/

        /*-------------------------------------------------------------------------*/

        /* Permanent general NAM items.  Each of these is associated with a        */
        /* particular NAM (there are up to four NAMs per unit).  The NAM id is     */
        /* specified in the request.  Certain analog parameters are truly          */
        /* associated with the MIN, but since there is only one MIN per NAM        */
        /* in analog mode they are defined as a NAM item.                          */

        NV_PREF_MODE_I,          /* Digital/Analog mode preference        */ /*10*/
        NV_CDMA_PREF_SERV_I,     /* CDMA preferred serving system (A/B)          */
        NV_ANALOG_PREF_SERV_I,   /* Analog preferred serving system (A/B)        */

        /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/

        /* The NAM parameters in the block below are protected by the NAM          */
        /* checksum and can only be programmed via service programming.            */
        /* The NAM parameters in the block above are not protected by checksum     */
        /* and may be changed by the user 'on the fly'.                            */

        NV_CDMA_SID_LOCK_I,      /* CDMA SID(s) to lockout                       */
        NV_CDMA_SID_ACQ_I,       /* CDMA SID to acquire                          */
        NV_ANALOG_SID_LOCK_I,    /* ANALOG SID(s) to lockout                     */
        NV_ANALOG_SID_ACQ_I,     /* ANALOG SID to acquire                        */
        NV_ANALOG_FIRSTCHP_I,    /* Analog FIRSTCHPp                             */
        NV_ANALOG_HOME_SID_I,    /* Analog HOME_SIDp                             */
        NV_ANALOG_REG_I,         /* Analog registration setting                  */
        NV_PCDMACH_I,            /* Primary CDMA channel   */                /*20*/
        NV_SCDMACH_I,            /* Secondary CDMA channel                       */
        NV_PPCNCH_I,             /* Primary PCN channel                          */
        NV_SPCNCH_I,             /* Secondary PCN channel                        */
        NV_NAM_CHKSUM_I,         /* NAM checksum                                 */

        /*-------------------------------------------------------------------------*/

        /* Authentication NAM items.  Each of these is associated with a NAM       */
        /* authentication (there are up to four NAMs per unit).  The NAM id is     */
        /* specified in the request.                                               */

        NV_A_KEY_I,              /* Authentication A key                         */
        NV_A_KEY_CHKSUM_I,       /* Authentication A key checksum                */
        NV_SSD_A_I,              /* SSD_Asp                                      */
        NV_SSD_A_CHKSUM_I,       /* SSD_Asp checksum                             */
        NV_SSD_B_I,              /* SSD_Bsp                                      */
        NV_SSD_B_CHKSUM_I,       /* SSD_Bsp checksum        */               /*30*/
        NV_COUNT_I,              /* COUNTsp                                      */

        /*-------------------------------------------------------------------------*/

        /* MIN items.  Each of these is associated with a particular MIN within    */
        /* the NAM (there are up to 2 MINs per NAM).  The MIN id itself is         */
        /* specified in the request.  When operating in analog mode the first MIN  */
        /* is the one and only meaningfull one.                                    */

        NV_MIN1_I,               /* MIN1p                                        */
        NV_MIN2_I,               /* MIN2p                                        */
        NV_MOB_TERM_HOME_I,      /* CDMA MOB_TERM_HOMEp registration flag        */
        NV_MOB_TERM_FOR_SID_I,   /* CDMA MOB_TERM_FOR_SIDp registration flag     */
        NV_MOB_TERM_FOR_NID_I,   /* CDMA MOB_TERM_FOR_NIDp registration flag     */
        NV_ACCOLC_I,             /* ACCOLCp                                      */
        NV_SID_NID_I,            /* CDMA SID/NID pairs                           */
        NV_MIN_CHKSUM_I,         /* MIN checksum                                 */

        /*-------------------------------------------------------------------------*/

        /* Operational NAM settings.                                               */

        NV_CURR_NAM_I,           /* Current NAM     */                       /*40*/
        NV_ORIG_MIN_I,           /* Call origination MIN within NAM              */
        NV_AUTO_NAM_I,           /* Select NAM automatically on roaming          */
        NV_NAME_NAM_I,           /* A user selectable name for each NAM          */

        /*-------------------------------------------------------------------------*/

        /* Semi-permanent analog registration parameters.                          */

        NV_NXTREG_I,             /* NXTREGsp                                     */
        NV_LSTSID_I,             /* SIDsp (last SID registered)                  */
        NV_LOCAID_I,             /* LOCAIDsp                                     */
        NV_PUREG_I,              /* PUREGsp                                      */

        /*-------------------------------------------------------------------------*/

        /* Semi-permanent CDMA registration and channel parameters.                */

        NV_ZONE_LIST_I,          /* ZONE_LISTsp                                  */
        NV_SID_NID_LIST_I,       /* SID_NID_LISTsp                               */
        NV_DIST_REG_I,           /* Distance registration variables   */     /*50*/
        NV_LAST_CDMACH_I,        /* Last CDMA channel acquired                   */

        /*-------------------------------------------------------------------------*/

        /* Timers, each associated with a specific NAM.                            */

        NV_CALL_TIMER_I,      /* Last call time                                  */
        NV_AIR_TIMER_I,       /* Air time (resettable cummulative call timer)    */
        NV_ROAM_TIMER_I,      /* Roam time (resettable cummulative roam timer)   */
        NV_LIFE_TIMER_I,      /* Life time (non-resettable cumm. call timer)     */

        /*-------------------------------------------------------------------------*/

        /* Run timer, independent of NAM.                                          */

        NV_RUN_TIMER_I,       /* Run timer (time hardware has been running)      */

        /*-------------------------------------------------------------------------*/

        /* Memory (speed) dial numbers.                                            */

        NV_DIAL_I,            /* Speed dial number                               */
        NV_STACK_I,           /* Call stack number                               */
        NV_STACK_IDX_I,       /* Call stack last number index                    */

        /*-------------------------------------------------------------------------*/

        /* Telephone pages (obsolete).                                             */

        NV_PAGE_SET_I,        /* OBSOLETE Page setting     */                /*60*/
        NV_PAGE_MSG_I,        /* OBSOLETE Page message and time                  */

        /*-------------------------------------------------------------------------*/

        /* Volumes.                                                                */

        NV_EAR_LVL_I,         /* Handset ear piece volume level                  */
        NV_SPEAKER_LVL_I,     /* Handsfree speaker volume level                  */
        NV_RINGER_LVL_I,      /* Ringer volume level                             */
        NV_BEEP_LVL_I,        /* Key beep volume level                           */

        /*-------------------------------------------------------------------------*/

        /* Tones.                                                                  */

        NV_CALL_BEEP_I,       /* One minute call beeper select                   */
        NV_CONT_KEY_DTMF_I,   /* Continuous keypad DTMF tones select             */
        NV_CONT_STR_DTMF_I,   /* Continuous string (memory) DTMF tones select    */
        NV_SVC_AREA_ALERT_I,  /* Service area enter/exit alert select            */
        NV_CALL_FADE_ALERT_I, /* Call fade alert select     */               /*70*/

        /*-------------------------------------------------------------------------*/

        /* Various phone settings.                                                 */

        NV_BANNER_I,          /* Idle banner to display                          */
        NV_LCD_I,             /* Display brightness setting                      */
        NV_AUTO_POWER_I,      /* Auto power settings (power savings)             */
        NV_AUTO_ANSWER_I,     /* Auto answer setting                             */
        NV_AUTO_REDIAL_I,     /* Auto redial setting                             */
        NV_AUTO_HYPHEN_I,     /* Auto hyphen setting                             */
        NV_BACK_LIGHT_I,      /* Backlighting manual/auto mode                   */
        NV_AUTO_MUTE_I,       /* Auto radio mute setting                         */

        /*-------------------------------------------------------------------------*/

        /* Locks and restrictions values.                                          */

        NV_MAINTRSN_I,    /* Base station maintance required reason              */
        NV_LCKRSN_P_I,    /* Base station lock reason, until power cycled */ /*80*/
        NV_LOCK_I,        /* Indicator of whether user locked the phone          */
        NV_LOCK_CODE_I,   /* Lock code string                                    */
        NV_AUTO_LOCK_I,   /* Auto lock setting                                   */
        NV_CALL_RSTRC_I,  /* Call restrictions                                   */
        NV_SEC_CODE_I,    /* Security code                                       */
        NV_HORN_ALERT_I,  /* Horn alert setting                                  */

        /*-------------------------------------------------------------------------*/

        /* Error log.                                                              */

        NV_ERR_LOG_I,         /* Error log                                       */

        /*-------------------------------------------------------------------------*/

        /* Miscellaneous items.                                                    */

        NV_UNIT_ID_I,         /* Unit hardware id  (obsolete)                    */
        NV_FREQ_ADJ_I,        /* Frequency adjust values  (obsolete)             */

        /*-------------------------------------------------------------------------*/

        /* V Battery Min/Max.   (Portable Only Item)                               */

        NV_VBATT_I,           /* V battery regulator array for min/max */    /*90*/

        /*-------------------------------------------------------------------------*/

        /* Analog (FM) Transmit power levels                                       */

        NV_FM_TX_PWR_I,       /* Analog TX power level array                     */

        /*-------------------------------------------------------------------------*/

        /* Frequency/temperature offset table item                                 */

        NV_FR_TEMP_OFFSET_I,

        /*-------------------------------------------------------------------------*/

        /* DM Port Mode (Mobiles only) NOTE: Use to be NV_EXT_PORT_MODE_I          */

        NV_DM_IO_MODE_I,      /* External port (I/O) mode for DM service         */

        /*-------------------------------------------------------------------------*/

        /* Portable Turnaround Compensation Tables  (Portable Only)                */

        NV_CDMA_TX_LIMIT_I,   /* To limit TX_GAIN_ADJ when output exceeded       */
        NV_FM_RSSI_I,         /* Analog RSSI adjustment                          */
        NV_CDMA_RIPPLE_I,     /* CDMA UHF Ripple Compensation                    */
        NV_CDMA_RX_OFFSET_I,  /* CDMA RX Offset compensation                     */
        NV_CDMA_RX_POWER_I,   /* CDMA True RX Power Table                        */
        NV_CDMA_RX_ERROR_I,   /* CDMA RX Linear and Non-linear error table       */
        NV_CDMA_TX_SLOPE_1_I, /* CDMA TX Gain Comp Slope Compensation tbl*/ /*100*/
        NV_CDMA_TX_SLOPE_2_I, /* CDMA TX Gain Adjust Slope Compensation table    */
        NV_CDMA_TX_ERROR_I,   /* CDMA TX Non-linear Error Compensation table     */
        NV_PA_CURRENT_CTL_I,  /* PA Current Control table                        */
        /*-------------------------------------------------------------------------*/

        /* Audio Adjustment values                                                 */

        NV_SONY_ATTEN_1_I,
        NV_SONY_ATTEN_2_I,
        NV_VOC_GAIN_I,

        /*-------------------------------------------------------------------------*/

        /* Spare items (2) for developer                                           */

        NV_SPARE_1_I,
        NV_SPARE_2_I,

        /*-------------------------------------------------------------------------*/

        /* Data Services items                                                     */

        NV_DATA_SRVC_STATE_I,   /* Data Service(Task) Enabled/Disabled           */
        NV_DATA_IO_MODE_I,      /* External port (I/O) mode for Data svc */ /*110*/
        NV_IDLE_DATA_TIMEOUT_I, /* Data service idle time in seconds             */

        /*-------------------------------------------------------------------------*/

        /* Maximum TX adjustment                                                   */

        NV_MAX_TX_ADJ_I,

        /*-------------------------------------------------------------------------*/

        /* Initial Muting Modes                                                    */

        NV_INI_MUTE_I,

        /*-------------------------------------------------------------------------*/

        /* Factory free format test buffer                                         */

        NV_FACTORY_INFO_I,

        /*-------------------------------------------------------------------------*/

        /* Additional Sony Attenuation values                                      */

        NV_SONY_ATTEN_3_I,
        NV_SONY_ATTEN_4_I,
        NV_SONY_ATTEN_5_I,

        /*-------------------------------------------------------------------------*/

        /* DM address item (for multi-drop HDLC)                                   */

        NV_DM_ADDR_I,
        NV_CDMA_PN_MASK_I,
        NV_SEND_TIMEOUT_I,                                                  /*120*/

        /*-------------------------------------------------------------------------*/
        /* MSM2P and beyond NV items. */

        NV_FM_AGC_SET_VS_PWR_I,        /* FM TX_AGC_ADJ setting vs power         */
        NV_FM_AGC_SET_VS_FREQ_I,       /* FM TX_AGC_ADJ setting vs frequency     */
        NV_FM_AGC_SET_VS_TEMP_I,       /* FM TX_AGC_ADJ setting vs temperature   */

        NV_FM_EXP_HDET_VS_PWR_I,       /* FM expected HDET reading vs power      */
        NV_FM_ERR_SLP_VS_PWR_I,        /* FM HDET error slope vs power           */
        NV_FM_FREQ_SENSE_GAIN_I,       /* deviation adj. trim                    */

        NV_CDMA_RX_LIN_OFF_0_I,        /* CDMA Rx linearizer offset              */
        NV_CDMA_RX_LIN_SLP_I,          /* CDMA Rx linearizer slope               */

        NV_CDMA_RX_COMP_VS_FREQ_I,     /* CDMA Rx gain comp vs frequency         */
        NV_CDMA_TX_COMP_VS_FREQ_I,     /* CDMA Tx gain comp vs frequency */ /*130*/
        NV_CDMA_TX_COMP_VS_VOLT_I,     /* CDMA Tx gain comp vs voltage           */

        NV_CDMA_TX_LIN_MASTER_OFF_0_I, /* CDMA Tx linearizer master offset       */
        NV_CDMA_TX_LIN_MASTER_SLP_I,   /* CDMA Tx linearizer master slope        */
        NV_CDMA_TX_LIN_VS_TEMP_I,      /* CDMA Tx linearizer trim vs temp        */
        NV_CDMA_TX_LIN_VS_VOLT_I,      /* CDMA Tx linearizer trim vs voltage     */

        NV_CDMA_TX_LIM_VS_TEMP_I,      /* CDMA Tx power limit vs temperature     */
        NV_CDMA_TX_LIM_VS_VOLT_I,      /* CDMA Tx power limit vs voltage         */
        NV_CDMA_TX_LIM_VS_FREQ_I,      /* CDMA Tx power limit vs frequency       */
        NV_CDMA_EXP_HDET_VS_AGC_I,     /* CDMA expected HDET reading vs AGC PDM  */
        NV_CDMA_ERR_SLP_VS_HDET_I,  /*CDMA HDET err slope vs HDET reading*/ /*140*/

        NV_THERM_I,                    /* RF & LCD temp. based compensation      */
        NV_VBATT_PA_I,                 /* RF comp. based on voltage              */
        NV_HDET_OFF_I,                 /* ADC HDET reading offset                */
        NV_HDET_SPN_I,                 /* ADC HDET reading span                  */
        NV_ONETOUCH_DIAL_I,            /* ena/dis UI one touch dialing           */

        NV_FM_AGC_ADJ_VS_FREQ_I,
        NV_FM_AGC_ADJ_VS_TEMP_I,
        NV_RF_CONFIG_I,
        NV_R1_RISE_I,
        NV_R1_FALL_I,                                                       /*150*/
        NV_R2_RISE_I,
        NV_R2_FALL_I,
        NV_R3_RISE_I,
        NV_R3_FALL_I,

        NV_PA_RANGE_STEP_CAL_I,
        NV_LNA_RANGE_POL_I,
        NV_LNA_RANGE_RISE_I,
        NV_LNA_RANGE_FALL_I,
        NV_LNA_RANGE_OFFSET_I,

        NV_POWER_CYCLES_I,                                                  /*160*/
        NV_ALERTS_LVL_I,
        NV_ALERTS_LVL_SHADOW_I,
        NV_RINGER_LVL_SHADOW_I,
        NV_BEEP_LVL_SHADOW_I,
        NV_EAR_LVL_SHADOW_I,
        NV_TIME_SHOW_I,
        NV_MESSAGE_ALERT_I,
        NV_AIR_CNT_I,
        NV_ROAM_CNT_I,
        NV_LIFE_CNT_I,                                                      /*170*/
        NV_SEND_PIN_I,
        NV_AUTO_ANSWER_SHADOW_I,
        NV_AUTO_REDIAL_SHADOW_I,
        NV_SMS_I,
        NV_SMS_DM_I,
        NV_IMSI_MCC_I,
        NV_IMSI_11_12_I,
        NV_DIR_NUMBER_I,
        NV_VOICE_PRIV_I,
        NV_SPARE_B1_I,                                                      /*180*/
        NV_SPARE_B2_I,
        NV_SPARE_W1_I,
        NV_SPARE_W2_I,
        NV_FSC_I,
        NV_ALARMS_I,
        NV_STANDING_ALARM_I,
        NV_ISD_STD_PASSWD_I,
        NV_ISD_STD_RESTRICT_I,
        NV_DIALING_PLAN_I,
        NV_FM_LNA_CTL_I,                                                    /*190*/
        NV_LIFE_TIMER_G_I,
        NV_CALL_TIMER_G_I,
        NV_PWR_DWN_CNT_I,
        NV_FM_AGC_I,
        NV_FSC2_I,
        NV_FSC2_CHKSUM_I,
        NV_WDC_I,
        NV_HW_CONFIG_I,

        /*-------------------------------------------------------------------------*/
        /* MSM2P and beyond NV items. (continued)  */

        NV_CDMA_RX_LIN_VS_TEMP_I,            /* CDMA Rx linearizer vs temperature*/
        NV_CDMA_ADJ_FACTOR_I,                /* CDMA adjustment factor */   /*200*/
        NV_CDMA_TX_LIM_BOOSTER_OFF_I,
        NV_CDMA_RX_SLP_VS_TEMP_I,
        NV_CDMA_TX_SLP_VS_TEMP_I,
        NV_PA_RANGE_VS_TEMP_I,
        NV_LNA_SWITCH_VS_TEMP_I,
        NV_FM_EXP_HDET_VS_TEMP_I,
        NV_N1M_I,

        /*-------------------------------------------------------------------------*/
        /* J-STD-008 NAM parameters and extensions.                                */

        NV_IMSI_I,                        /* OBSOLETE InternationaMobileStationID*/
        NV_IMSI_ADDR_NUM_I,                  /* Length of IMSI                   */
        NV_ASSIGNING_TMSI_ZONE_LEN_I,        /* TMSI_ZONE_LENs-p  */        /*210*/
        NV_ASSIGNING_TMSI_ZONE_I,            /* TMSI_ZONEs-p                     */
        NV_TMSI_CODE_I,                      /* TMSI_CODEs-p                     */
        NV_TMSI_EXP_I,                       /* TMSI expiration time             */
        NV_HOME_PCS_FREQ_BLOCK_I,            /* Subscriber's home block          */
        NV_DIR_NUMBER_PCS_I,                 /* Directory number, PCS format     */

        /*-------------------------------------------------------------------------*/
        /* Roaming List and MRU Table.                                             */

        NV_ROAMING_LIST_I,                   /* The roaming list                 */
        NV_MRU_TABLE_I,                      /* Most recently used channels      */
        /*  NOTE: This item is obsolete     */

        /*-------------------------------------------------------------------------*/

        NV_REDIAL_I,                 /* Last number redial                       */
        NV_OTKSL_I,                  /* One-time keypad subsidy lock             */
        NV_TIMED_PREF_MODE_I,        /* To allow analog-only operation */   /*220*/

        /*-------------------------------------------------------------------------*/

        NV_RINGER_TYPE_I,            /* Ringer type setting                      */
        NV_ANY_KEY_ANSWER_I,         /* Answer call with any key                 */
        NV_BACK_LIGHT_HFK_I,         /* Hands Free Kit backlight setting         */
        NV_RESTRICT_GLOBAL_I,        /* Global phone book restriction            */
        NV_KEY_SOUND_I,              /* Type of keypress sound emitted           */
        NV_DIALS_SORTING_METHOD_I,   /* Phone book sorting method                */
        NV_LANGUAGE_SELECTION_I,     /* Language for user interface              */
        NV_MENU_FORMAT_I,            /* Type of user interface menus             */

        /*-------------------------------------------------------------------------*/

        NV_RINGER_SPKR_LVL_I,        /* External speaker ringer volume           */
        NV_BEEP_SPKR_LVL_I,          /* External speaker key beep volume */ /*230*/

        /*-------------------------------------------------------------------------*/

        NV_MRU2_TABLE_I,             /* New format, Most Recently Used channels  */
        NV_VIBRATOR_I,               /* Use vibrator instead of ringer           */
        NV_FLIP_ANSWERS_I,           /* Opening clamshell answers call           */

        /*-------------------------------------------------------------------------*/

        NV_DIAL_RESTRICT_LVLS_I,     /* ISS2 dialing restriction levels          */
        NV_DIAL_STATE_TABLE_LEN_I,   /* Number elements in state table           */
        NV_DIAL_STATE_TABLE_I,       /* ISS2 dialing plan state table            */

        /*-------------------------------------------------------------------------*/

        NV_VOICE_PRIV_ALERT_I,       /* Voice privacy alert for TGP              */

        /*-------------------------------------------------------------------------*/

        NV_IP_ADDRESS_I,             /* IP/Port address  (obsolete)              */
        NV_CURR_GATEWAY_I,           /* Last active IP address (obsolete)        */

        /*-------------------------------------------------------------------------*/

        NV_DATA_QNC_ENABLED_I,       /* QNC enabled flag                 */ /*240*/
        NV_DATA_SO_SET_I,            /* Which Service Option set is in effect    */

        /*-------------------------------------------------------------------------*/

        NV_UP_LINK_INFO_I,           /* IP addresses and key data                */
        NV_UP_PARMS_I,               /* Current gateway, alert state, etc.       */
        NV_UP_CACHE_I,               /* The Unwired Planet cache                 */

        /*-------------------------------------------------------------------------*/

        NV_ELAPSED_TIME_I,           /* Timer for formal test use                */

        /*-------------------------------------------------------------------------*/

        NV_PDM2_I,                   /* For RF Cal use                           */
        NV_RX_AGC_MINMAX_I,          /* Receiver AGC min-max                     */
        NV_VBATT_AUX_I,              /* Auxillary VBATT min-max                  */

        NV_DTACO_CONTROL_I,            /* DTACO enabled/disabled control         */
        NV_DTACO_INTERDIGIT_TIMEOUT_I, /* DTACO interdigit timeout       */ /*250*/

        NV_PDM1_I,                   /* For RF Cal use                           */
        NV_BELL_MODEM_I,             /* Flag for ISS2                            */

        NV_PDM1_VS_TEMP_I,           /* For RF Cal use                           */
        NV_PDM2_VS_TEMP_I,           /* For RF Cal use                           */

        /*-------------------------------------------------------------------------*/

        NV_SID_NID_LOCK_I,           /* CDMA SID(s) and NID(s) to lockout        */
        NV_PRL_ENABLED_I,            /* If the roaming list is enabled or not    */
        NV_ROAMING_LIST_683_I,       /* IS-683-A format roaming list             */
        NV_SYSTEM_PREF_I,            /* System Preference, per NAM               */
        NV_HOME_SID_NID_I,           /* "Home" SID/NID list                      */
        NV_OTAPA_ENABLED_I,          /* Whether OTAPA is enabled, per NAM*/ /*260*/
        NV_NAM_LOCK_I,               /* SPASM protection per NAM                 */
        NV_IMSI_T_S1_I,              /* True IMSI - MIN1                         */
        NV_IMSI_T_S2_I,              /* True IMSI - MIN2                         */
        NV_IMSI_T_MCC_I,             /* True IMSI - MCC                          */
        NV_IMSI_T_11_12_I,           /* True IMSI - 11th & 12th digits           */
        NV_IMSI_T_ADDR_NUM_I,        /* True IMSI - Addr num                     */

        /*-------------------------------------------------------------------------*/

        NV_UP_ALERTS_I,              /* Unwired Planet alert records             */
        NV_UP_IDLE_TIMER_I,          /* Idle time timer                          */

        NV_SMS_UTC_I,                /* Specifies format of SMS time display     */
        NV_ROAM_RINGER_I,            /* Specifies roam ringer on or off  */ /*270*/
        NV_RENTAL_TIMER_I,           /* The rental timer item                    */
        NV_RENTAL_TIMER_INC_I,       /* The rental timer increment value         */
        NV_RENTAL_CNT_I,             /* The rental counter                       */
        NV_RENTAL_TIMER_ENABLED_I,   /* Enables/disables the rental timer        */
        NV_FULL_SYSTEM_PREF_I,       /* Controls system pref display options     */

        /*-------------------------------------------------------------------------*/

        NV_BORSCHT_RINGER_FREQ_I,    /* Ringer freq used for BORSCHT port (RJ-11)*/
        NV_PAYPHONE_ENABLE_I,        /* Enable/disable payphone support          */
        NV_DSP_ANSWER_DET_ENABLE_I,  /* Enable/disable dsp answer detection      */
        NV_EVRC_PRI_I,               /* EVRC/13K priority: EVRC first, 13K first */
        NV_AFAX_CLASS_20_I,          /* Obsolete item                    */ /*280*/
        NV_V52_CONTROL_I,            /* V52 control option                       */
        NV_CARRIER_INFO_I,           /* Bitmap and ASCII name info for carrier   */
        NV_AFAX_I,                   /* Analog FAX type: end to end or class 2.0 */
        NV_SIO_PWRDWN_I,             /* Distinguishes old/new UART hardware      */

        /*-------------------------------------------------------------------------*/

        NV_PREF_VOICE_SO_I,          /* EVRC voice service options               */
        NV_VRHFK_ENABLED_I,          /* Voice recognition hands free kit enabled */
        NV_VRHFK_VOICE_ANSWER_I,     /* Voice recognition voice answer           */
        NV_PDM1_VS_FREQ_I,           /* For RF Cal use                           */
        NV_PDM2_VS_FREQ_I,           /* For RF Cal use                           */
        NV_SMS_AUTO_DELETE_I,        /* SMS auto-deletion enabled status */ /*290*/
        NV_SRDA_ENABLED_I,           /* Silent redial enabled status             */
        NV_OUTPUT_UI_KEYS_I,         /* Enable-disable sending UI keystrokes     */
        NV_POL_REV_TIMEOUT_I,        /* Timeout for polarity reversal            */

        /*-------------------------------------------------------------------------*/

        NV_SI_TEST_DATA_1_I,         /* First stack-checker diagnostic buffer    */
        NV_SI_TEST_DATA_2_I,         /* Second stack-checker diagnostic buffer   */
        NV_SPC_CHANGE_ENABLED_I,     /* Enable-disable OTASP SPC change          */

        NV_DATA_MDR_MODE_I,          /* Select the MDR mode                      */
        NV_DATA_PKT_ORIG_STR_I,      /* Dial string for originating packet calls */

        NV_UP_KEY_I,                 /* Unwired Planet access key item           */
        NV_DATA_AUTO_PACKET_DETECTION_I, /* Packet data config item      */ /*300*/
        NV_AUTO_VOLUME_ENABLED_I,    /* Enable-disable auto volume               */
        NV_WILDCARD_SID_I,           /* Allow wildcard SID                       */
        NV_ROAM_MSG_I,               /* Downloadable roaming messages            */
        NV_OTKSL_FLAG_I,             /* OTKSL Flag                               */
        NV_BROWSER_TYPE_I,           /* Browser identifier                       */
        NV_SMS_REMINDER_TONE_I,      /* Reminder tone is on or off               */

        /*-------------------------------------------------------------------------*/

        NV_UBROWSER_I,               /* Micro browser data                       */
        NV_BTF_ADJUST_I,             /* BTF adjustment value                     */
        NV_FULL_PREF_MODE_I,         /* Controls pref display options            */
        NV_UP_BROWSER_WARN_I,        /* Confirmation screen option       */ /*310*/
        NV_FM_HDET_ADC_RANGE_I,      /* ADC range for HDET sampling (analog)     */
        NV_CDMA_HDET_ADC_RANGE_I,    /* ADC range for HDET sampling (CDMA)       */
        NV_PN_ID_I,                  /* PN code selection                        */
        NV_USER_ZONE_ENABLED_I,      /* Enable-disable User Zone table           */
        NV_USER_ZONE_I,              /* User Zone table                          */
        NV_PAP_DATA_I,               /* Password Authentication Protocol data    */
        NV_DATA_DEFAULT_PROFILE_I,   /* Default user AT command profile          */
        NV_PAP_USER_ID_I,            /* User_ID for Password Auth. Protocol      */
        NV_PAP_PASSWORD_I,           /* Actual password for PAP                  */
        NV_STA_TBYE_I,               /* Num wakeup samples below thrshld */ /*320*/
        NV_STA_MIN_THR_I,            /* Threshold for Rx+Ec/Io (RSSI) trigger    */
        NV_STA_MIN_RX_I,             /* Threshold for Rx trigger                 */
        NV_STA_MIN_ECIO_I,           /* Threshold for Rx-Only idle trigger       */
        NV_STA_PRI_I,                /* Switch to AMPS PRI setting               */

        /*-------------------------------------------------------------------------*/

        NV_PCS_RX_LIN_OFF_0_I,       /* PCS Rx linearizer offset                 */
        NV_PCS_RX_LIN_SLP_I,         /* PCS Rx linearizer slope                  */
        NV_PCS_RX_COMP_VS_FREQ_I,    /* PCS Rx gain comp vs frequency            */
        NV_PCS_TX_COMP_VS_FREQ_I,    /* PCS Tx gain comp vs frequency            */
        NV_PCS_TX_LIN_MASTER_OFF_0_I,/* PCS Tx linearizer master offset          */
        NV_PCS_TX_LIN_MASTER_SLP_I,  /* PCS Tx linearizer master slope   */ /*330*/
        NV_PCS_TX_LIN_VS_TEMP_I,     /* PCS Tx linearizer trim vs temp           */
        NV_PCS_TX_LIM_VS_TEMP_I,     /* PCS Tx power limit vs temperature        */
        NV_PCS_TX_LIM_VS_FREQ_I,     /* PCS Tx power limit vs frequency          */
        NV_PCS_EXP_HDET_VS_AGC_I,    /* PCS expected HDET reading vs AGC PDM     */
        NV_PCS_HDET_OFF_I,           /* ADC HDET reading offset                  */
        NV_PCS_HDET_SPN_I,           /* ADC HDET reading span                    */
        NV_PCS_R1_RISE_I,            /* TX pwr lvl at which PA is stepped up     */
        NV_PCS_R1_FALL_I,            /* TX pwr lvl at which PA is stepped down   */
        NV_PCS_R2_RISE_I,            /* TX pwr lvl at which PA is stepped up     */
        NV_PCS_R2_FALL_I,            /* TX pwr lvl at which PA stpd down */ /*340*/
        NV_PCS_R3_RISE_I,            /* TX pwr lvl at which PA is stepped up     */
        NV_PCS_R3_FALL_I,            /* TX pwr lvl at which PA is stepped down   */
        NV_PCS_PA_RANGE_STEP_CAL_I,  /* Calibrate PA Range gain step             */
        NV_PCS_PDM1_VS_FREQ_I,       /* PDM1 vs frequency compensation table     */
        NV_PCS_PDM2_VS_FREQ_I,       /* PDM2 vs frequency compensation table     */
        NV_PCS_LNA_RANGE_POL_I,      /* Polarity of LNA range control signal     */
        NV_PCS_LNA_RANGE_RISE_I,     /* Rx pwr lvl for: LNA bypass               */
        NV_PCS_LNA_RANGE_FALL_I,     /* Rx pwr lvl for: LNA turned on            */
        NV_PCS_LNA_RANGE_OFFSET_I,   /* Rx pwr lvl offset when LNA is bypassed   */
        NV_PCS_RX_LIN_VS_TEMP_I,     /* PCS Rx linearizer vs temperature */ /*350*/
        NV_PCS_ADJ_FACTOR_I,         /* PCS adjustment factor                    */
        NV_PCS_PA_RANGE_VS_TEMP_I,   /* Changes in PA_RANGE_STEP over temp       */
        NV_PCS_PDM1_VS_TEMP_I,       /* TX temperature compensation using PDM1   */
        NV_PCS_PDM2_VS_TEMP_I,       /* TX temperature compensation using PDM2   */
        NV_PCS_RX_SLP_VS_TEMP_I,     /* Slope of RX linearizer over temperature  */
        NV_PCS_TX_SLP_VS_TEMP_I,     /* Slope of TX linearizer over temperature  */
        NV_PCS_RX_AGC_MINMAX_I,      /* Receiver AGC min-max                     */

        /*-------------------------------------------------------------------------*/

        NV_PA_OFFSETS_I,
        NV_CDMA_TX_LIN_MASTER_I,

        // Items added by hand to support QCP-2035
        NV_VEXT_I,
        NV_VLCD_ADC_CNT_I,
        NV_VLCD_DRVR_CNT_I,
        NV_VREF_ADJ_PDM_CNT_I,
        NV_IBAT_PER_LSB_I,
        NV_IEXT_I,
        NV_IEXT_THR_I,

        NV_CDMA_TX_LIN_MASTER0_I,
        NV_CDMA_TX_LIN_MASTER1_I,
        NV_CDMA_TX_LIN_MASTER2_I,
        NV_CDMA_TX_LIN_MASTER3_I,                                           /*370*/
        NV_TIME_FMT_SELECTION_I,

        /*-------------------------------------------------------------------------*/

        NV_SMS_BC_SERVICE_TABLE_SIZE_I,
        NV_SMS_BC_SERVICE_TABLE_I,
        NV_SMS_BC_CONFIG_I,
        NV_SMS_BC_USER_PREF_I,

        /*-------------------------------------------------------------------------*/

        /* RFR3100 items */
        NV_LNA_RANGE_2_RISE_I,
        NV_LNA_RANGE_2_FALL_I,
        NV_LNA_RANGE_12_OFFSET_I,
        NV_NONBYPASS_TIMER_I,
        NV_BYPASS_TIMER_I,                                                  /*380*/
        NV_IM_LEVEL1_I,
        NV_IM_LEVEL2_I,
        NV_CDMA_LNA_OFFSET_VS_FREQ_I,
        NV_CDMA_LNA_12_OFFSET_VS_FREQ_I,
        NV_AGC_PHASE_OFFSET_I,
        NV_RX_AGC_MIN_11_I,

        /*-------------------------------------------------------------------------*/

        /* Trimode - RFR3100 items */
        NV_PCS_LNA_RANGE_2_RISE_I,
        NV_PCS_LNA_RANGE_2_FALL_I,
        NV_PCS_LNA_RANGE_12_OFFSET_I,
        NV_PCS_NONBYPASS_TIMER_I,                                           /*390*/
        NV_PCS_BYPASS_TIMER_I,
        NV_PCS_IM_LEVEL1_I,
        NV_PCS_IM_LEVEL2_I,
        NV_PCS_CDMA_LNA_OFFSET_VS_FREQ_I,
        NV_PCS_CDMA_LNA_12_OFFSET_VS_FREQ_I,
        NV_PCS_AGC_PHASE_OFFSET_I,
        NV_PCS_RX_AGC_MIN_11_I,

        NV_RUIM_CHV_1_I,                 /* Card holder verification 1 for R-UIM */
        NV_RUIM_CHV_2_I,                 /* Card holder verification 2 for R-UIM */

        NV_GPS1_CAPABILITIES_I,                          /* GPS One Capabilities */
        NV_GPS1_PDE_ADDRESS_I,                        /* GPS One PDE TCP Address */
        NV_GPS1_ALLOWED_I,   /* GPS One Position Determination Services Lock-out */
        NV_GPS1_PDE_TRANSPORT_I,        /* GPS One Preferred transport mechanism */
        NV_GPS1_MOBILE_CALC_I,
        /* GPS One Mobile vs PDE based Position Calculations */

        NV_PREF_FOR_RC_I,        /* IS2000 CAI radio configuration RC preference */
        NV_DS_DEFAULT_BAUD_I,             /* DATA SERVICES default SIO baud rate */
        NV_DIAG_DEFAULT_BAUD_I,                    /* DIAG default SIO baud rate */
        NV_SIO_DEV_MAP_MENU_ITEM_I,
        /* Serial Device Mapper configuration menu item information */

        NV_TTY_I,                /* Specifies whether TTY is enabled or disabled */
        NV_PA_RANGE_OFFSETS_I,
        /* Digitally compensate for PA gain steps in each of the 4 PA states */
        NV_TX_COMP0_I,  /* For temp. and freq. compensation of the Tx linearizer */

        NV_MM_SDAC_LVL_I,                  /* Stereo DAC Multimedia volume level */
        NV_BEEP_SDAC_LVL_I,                  /* Stereo DAC key beep volume level */
        NV_SDAC_LVL_I,                                /* Stereo DAC volume level */
        NV_MM_LVL_I,                          /* Handset Multimedia volume level */
        NV_MM_LVL_SHADOW_I,                   /* Headset Multimedia volume level */
        NV_MM_SPEAKER_LVL_I,                      /* HFK Multimedia volume level */
        NV_MM_PLAY_MODE_I,                               /* Multimedia play mode */
        NV_MM_REPEAT_MODE_I,                           /* Multimedia repeat mode */
        NV_TX_COMP1_I,  /* For temp. and freq. compensation of the Tx linearizer */
        NV_TX_COMP2_I,  /* For temp. and freq. compensation of the Tx linearizer */
        NV_TX_COMP3_I,  /* For temp. and freq. compensation of the Tx linearizer */
        NV_PRIMARY_DNS_I,           /* Contains the IP Address of the DNS Server */
        NV_SECONDARY_DNS_I,
        /* Contains the IP Address of the Secondary DNS Server */
        NV_DIAG_PORT_SELECT_I,              /* Info for DIAG boot port selection */
        NV_GPS1_PDE_PORT_I,        /* Listening port associated with PDE address */
        NV_MM_RINGER_FILE_I,                       /* Multimedia ringer filename */
        NV_MM_STORAGE_DEVICE_I,                      /* Multimedia file location */

        NV_DATA_SCRM_ENABLED_I, /* Enables/disables the mobile's ability to SCRM */
        NV_RUIM_SMS_STATUS_I,                                              /*    */
        NV_PCS_TX_LIN_MASTER0_I,        /* PCS Tx linearizer with internal PA=00 */
        NV_PCS_TX_LIN_MASTER1_I,        /* PCS Tx linearizer with internal PA=01 */
        NV_PCS_TX_LIN_MASTER2_I,        /* PCS Tx linearizer with internal PA=10 */
        NV_PCS_TX_LIN_MASTER3_I,        /* PCS Tx linearizer with internal PA=11 */

        NV_PCS_PA_RANGE_OFFSETS_I,                       /* PCS PA range offsets */
        NV_PCS_TX_COMP0_I,        /* PCS transmit frequency compensation table 0 */
        NV_PCS_TX_COMP1_I,        /* PCS transmit frequency compensation table 1 */
        NV_PCS_TX_COMP2_I,        /* PCS transmit frequency compensation table 2 */
        NV_PCS_TX_COMP3_I,        /* PCS transmit frequency compensation table 3 */

        NV_DIAG_RESTART_CONFIG_I,
        /* One-time startup configuration for DIAG services */

        NV_BAND_PREF_I,   /* Stores the band-class preference on a per NAM basis */
        NV_ROAM_PREF_I,      /* Stores the roaming preference on a per NAM basis */

        NV_GPS1_GPS_RF_DELAY_I,                           /* GPS RF Signal Delay */
        /* The len. of time taken for a GPS signal to pass through the RF chain  */

        NV_GPS1_CDMA_RF_DELAY_I,                         /* CDMA RF Signal Delay */
        /* The len. of time taken for a CDMA signal to pass through the RF chain */

        NV_PCS_ENC_BTF_I,
        /* CHIPX8 delay for SYNC80M via 1900mhz PCS path in RF card, biased +25 */
        NV_CDMA_ENC_BTF_I,
        /* CHIPX8 delay for SYNC80M via 800mhz CDMA path in RF card, biased +25 */
        NV_BD_ADDR_I,               /* Holds the Bluetooth address of the mobile  447  */
        NV_SUBPCG_PA_WARMUP_DELAY_I,
        /* Provides the less-than-one-PCG warm-up for the PA */
        NV_GPS1_GPS_RF_LOSS_I,        /* RF Loss in GPR RF Chain in 0.1 DB Units */
        NV_DATA_TRTL_ENABLED_I,
        /* In IS2000, if mobile should self-throttle R-SCH */
        NV_AMPS_BACKSTOP_ENABLED_I,       /* AMPS backstop system enabled status */
        NV_GPS1_LOCK_I,                                   /* GPS One lock status */
        NV_FTM_MODE_I,    /* Determines boot up mode of a factory testmode phone */
        /* DATA SERVICES default SIO baud rate (obsoletes NV_DS_DEFAULT_BAUD_I)  */
        NV_DS_DEFAULT_BAUDRATE_I,
        /* DIAG default SIO baud rate     (obsoletes NV_DIAG_DEFAULT_BAUD_I)     */
        NV_DIAG_DEFAULT_BAUDRATE_I,
        NV_JCDMA_DS_F92_I,                  /* Stores JCDMA F92 option selected  */
        NV_IMEI_I,
        NV_IMEI_CHKSUM_I,
        NV_DS_QCMIP_I,                        /* The mode for Mobile IP behavior */
        NV_DS_MIP_RETRIES_I,
        /* The number of Mobile IP Registration Retries attempted */
        NV_DS_MIP_RETRY_INT_I,
        /* The initial interval between mobile IP registration attempts */
        NV_DS_MIP_PRE_RE_PRQ_TIME_I,
        /* The time before Mobile IP reg. expiration to attempt re-registration. */
        NV_DS_MIP_NUM_PROF_I,        /* Number of Mobile IP user profiles stored */
        NV_DS_MIP_ACTIVE_PROF_I,  /* The currently active Mobile IP user profile */
        NV_DS_MIP_GEN_USER_PROF_I,
        /* An instance of the Mobile IP general user profile. */
        NV_DS_MIP_SS_USER_PROF_I,
        /* An instance of the Mobile IP shared secret user profile */

        /* CON - advertised suspend time before sleep upon connection close */
        NV_HDR_CON_SUSPEND_I,
        /*  Preferred Control Channel Cycle Enabled   */
        NV_HDR_PRE_CC_CYC_ENABLED_I,
        /*  Preferred Control Channel Cycle                                      */
        NV_HDR_PRE_CC_CYC_I,
        /* HDR Search Parameters */
        NV_HDR_SRCH_PARAMS_I,
        /* SMP - Time at which keep alive timer was started */
        NV_HDRSMP_KEEP_ALIVE_START_I,
        /* SMP - Time at which keep alive message was last sent */
        NV_HDRSMP_KEEP_ALIVE_SENT_I,
        /* SMP - keep alive interval */
        NV_HDRSMP_KEEP_ALIVE_REQ_INT_I,
        /* AMP - all data related to addresses */
        NV_HDRAMP_ADDRESS_DATA_I,
        /* SCP - status of the session */
        NV_HDRSCP_SESSION_STATUS_I,
        /* SCP - session token (generated by AN) */
        NV_HDRSCP_TOKEN_I,
        /* SCP - list of all protocol subtypes */
        NV_HDRSCP_PROTOCOL_SUBTYPE_I,
        /* AMP - time at which the dual addresses expire */
        NV_HDRAMP_DUAL_EXPIRE_TIME_I,
        /* Configuration of current stream  */
        NV_HDRSTREAM_CURR_STREAM_CFG_I,
        /* HDR Set Management Same Channel Parameters */
        NV_HDR_SET_MNGMT_SAME_CHAN_I,
        /* HDR Set Management Different Channel Parameters */
        NV_HDR_SET_MNGMT_DIFF_CHAN_I,
        /* If we are configured to send unsolicited location updates */
        NV_HDRLUP_UNSOLICITED_ENABLED_I,
        /* HDR Access MAC InitialConfiguration Attribute */
        NV_HDRAMAC_INITIAL_CONFIG_I,
        /* HDR Access MAC PowerParameters Attribute */
        NV_HDRAMAC_POWER_PARAMS_I,
        /* Forward Traffic MAC DRC Gating Attribute */
        NV_HDRFMAC_DRC_GATING_I,
        /* Forward Traffic MAC HandoffDelays Attribute */
        NV_HDRFMAC_HANDOFF_DELAYS_I,
        /* Reverse Traffic MAC PowerParameters Attribute */
        NV_HDRRMAC_POWER_PARAMS_I,
        /* Reverse Traffic MAC RateParameters Attribute */
        NV_HDRRMAC_RATE_PARAMS_I,
        /* Next expected SLP ResetMsg Sequence Number (set to 0 at SessionBoot)  */
        NV_HDRSLP_RESET_SEQNO_I,
        /* The backoff values for the medium backoff calibration values          */
        NV_PWR_BACKOFF_VS_VOLT_MED_I,                                         /*490*/
        /* The backoff values for the low backoff calibration values             */
        NV_PWR_BACKOFF_VS_VOLT_LOW_I,
        /* Three voltages where PA Backoff was characterized                     */
        NV_PA_BACKOFF_VOLTS_I,
        /* High and low voltages for Vbatt ADC calib. counts                     */
        NV_VBATT_MIN_MAX_I,
        /* The timebase difference between the home agent and the mobile(in sec) */
        NV_DS_MIP_MN_HA_TIME_DELTA_I,
        /* Qualcomm PREV 6 MIP handoff optimization enable                       */
        NV_DS_MIP_QC_DRS_OPT_I,
        /* CDMA Rx linearizer offset for the second antenna                      */
        NV_ANT2_CDMA_RX_LIN_OFF_0_I,
        /* CDMA Rx linearizer slope for the second antenna                       */
        NV_ANT2_CDMA_RX_LIN_SLP_I,
        /* CDMA Rx gain comp vs frequency for the second antenna                 */
        NV_ANT2_CDMA_RX_COMP_VS_FREQ_I,
        /* CDMA Rx linearizer vs temperature for the second antenna              */
        NV_ANT2_CDMA_RX_LIN_VS_TEMP_I,
        /* PCS/CDMA RF Calibration items                                         */
        NV_ANT2_CDMA_RX_SLP_VS_TEMP_I,                                        /*500*/
        /* Value that is added to receive power reading when LNA is bypassed     */
        NV_ANT2_LNA_RANGE_OFFSET_I,
        /* Offset added to Rec. pwr when the 1st and 2nd LNAs are bypassed       */
        NV_ANT2_LNA_RANGE_12_OFFSET_I,
        /* NV_LNA_RANGE_OFFSET freq. compensation table, units of AGC value      */
        NV_ANT2_CDMA_LNA_OFFSET_VS_FREQ_I,
        /* NV_LNA_12_RANGE_OFFSET freq. compensation table, units of AGC value   */
        NV_ANT2_CDMA_LNA_12_OFFSET_VS_FREQ_I,
        /* PCS/CDMA mode Rx AGC linearization table                              */
        NV_ANT2_PCS_RX_LIN_OFF_0_I,
        /* PCS Rx linearizer slope for the second antenna                        */
        NV_ANT2_PCS_RX_LIN_SLP_I,
        /* PCS Rx gain comp vs frequency for the second antenna                  */
        NV_ANT2_PCS_RX_COMP_VS_FREQ_I,
        /* PCS Rx linearizer vs temperature for the second antenna               */
        NV_ANT2_PCS_RX_LIN_VS_TEMP_I,
        /* Slope variations of Master RX linearizer curve for the second antenna */
        NV_ANT2_PCS_RX_SLP_VS_TEMP_I,
        /* Value that is added to receive power reading when LNA is bypassed     */
        NV_ANT2_PCS_LNA_RANGE_OFFSET_I,                                       /*510*/
        /* Offset added to Rec. pwr when the 1st and 2nd LNAs are bypassed       */
        NV_ANT2_PCS_LNA_RANGE_12_OFFSET_I,
        /* NV_LNA_RANGE_OFFSET freq. compensation table, units of AGC value      */
        NV_ANT2_PCS_CDMA_LNA_OFFSET_VS_FREQ_I,
        /* NV_LNA_12_RANGE_OFFSET freq. compensation table, units of AGC value   */
        NV_ANT2_PCS_CDMA_LNA_12_OFFSET_VS_FREQ_I,
        NV_WCDMA_RX_LIN_I = 514,
        NV_WCDMA_RX_COMP_VS_FREQ_I = 515,
        NV_WCDMA_RX_LIN_VS_TEMP_I = 516,
        NV_WCDMA_RX_SLP_VS_TEMP_I = 517,
        NV_WCDMA_LNA_RANGE_POL_I = 518,
        NV_WCDMA_LNA_RANGE_RISE_I = 519,
        NV_WCDMA_LNA_RANGE_FALL_I = 520,
        NV_WCDMA_IM_LEVEL_I = 521,
        NV_WCDMA_NONBYPASS_TIMER_I = 522,
        NV_WCDMA_BYPASS_TIMER_I = 523,
        NV_WCDMA_LNA_RANGE_OFFSET_I = 524,
        NV_WCDMA_LNA_OFFSET_VS_FREQ_I = 525,
        NV_WCDMA_RX_AGC_MIN_I = 526,
        NV_WCDMA_RX_AGC_MAX_I = 527,
        NV_WCDMA_AGC_PHASE_OFFSET_I = 528,
        NV_WCDMA_TX_LIN_MASTER_0_I = 529,
        NV_WCDMA_TX_LIN_MASTER_1_I = 530,
        NV_WCDMA_TX_COMP_VS_FREQ_0_I = 531,
        NV_WCDMA_TX_COMP_VS_FREQ_1_I = 532,
        NV_WCDMA_TX_LIN_VS_TEMP_0_I = 533,
        NV_WCDMA_TX_LIN_VS_TEMP_1_I = 534,
        NV_WCDMA_TX_SLP_VS_TEMP_0_I = 535,
        NV_WCDMA_TX_SLP_VS_TEMP_1_I = 536,
        NV_WCDMA_R1_RISE_I = 537,
        NV_WCDMA_R1_FALL_I = 538,
        NV_WCDMA_TX_LIM_VS_TEMP_I = 539,
        NV_WCDMA_TX_LIM_VS_FREQ_I = 540,
        NV_WCDMA_ADJ_FACTOR_I = 541,
        NV_WCDMA_EXP_HDET_VS_AGC_I = 542,
        NV_WCDMA_HDET_OFF_I = 543,
        NV_WCDMA_HDET_SPN_I = 544,
        NV_WCDMA_ENC_BTF_I = 545,

        /* RFC2002bis MN-HA authenticator calculation                            */
        NV_DS_MIP_2002BIS_MN_HA_AUTH_I,

        NV_UE_RAT_CAPABILITY_I = 547,
        NV_GSM_UE_OP_CLASS_I = 548,
        NV_UMTS_UE_OP_CLASS_I = 549,
        NV_UE_IMEI_I = 550,
        NV_MSRAC_SMS_VALUE_I = 551,
        NV_MSRAC_SM_VALUE_I = 552,
        NV_GSM_A5_ALGORITHMS_SUPPORTED_I = 553,

        /* Configurable parameters for DRC Lock in HDR                           */
        NV_HDRFMAC_DRC_LOCK_I,
        /* LO Calibration offset                                                 */
        NV_GPS1_LO_CAL_I,
        /* GPS Antenna offset in DB                                              */
        NV_GPS1_ANT_OFF_DB_I,
        /* The len. of time taken for a PCS signal to pass through the RF chain  */
        NV_GPS1_PCS_RF_DELAY_I,

        NV_SMS_VM_NUMBER_I = 558,
        NV_SMS_GW_PARMS_I = 559, // item > 128 bytes!
        NV_SMS_ROUTING_I = 560,
        NV_SMS_GW_I = 561, // item > 128 bytes!

        /* Preferred mode in hybrid operation                                    */
        NV_HYBRID_PREF_I,
        /* If Service Provider ECC is enabled                                    */
        NV_SP_ECC_ENABLED_I,
        /* Emergency Call Codes to be used for an emergency call without a SIM   */
        NV_ECC_LIST_I,
        /* Latitude value for the Bluetooth LPOS application                     */
        NV_BT_LPOS_LAT_I,
        /* Longitude value for the Bluetooth LPOS application                    */
        NV_BT_LPOS_LONG_I,
        /* Embedded Phone-t Version                                              */
        NV_TEST_CODE_VER_I,
        /* DMSS S/W Version                                                      */
        NV_SYS_SW_VER_I,
        /* RF CAL Program version                                                */
        NV_RF_CAL_VER_I,
        /* RF CAL configuration file version                                     */
        NV_RF_CONFIG_VER_I,
        /* Date RF calibration was done                                          */
        NV_RF_CAL_DATE_I,
        /* Date RF calibration data loaded                                       */
        NV_RF_NV_LOADED_DATE_I,
        /* Name of RFCAL .dat                                                    */
        NV_RF_CAL_DAT_FILE_I,
        /* Data Services domain name                                             */
        NV_DOMAIN_NAME_I,
        /* The preferred network selection mode, either manual or automatic.     */
        NV_NETWORK_SEL_MODE_I,
        /* The preferred service type, i.e. circuit switched, packet switched... */
        NV_SERVICE_TYPE_I,
        /* The Public Land Mobile Network preferred by the user                  */
        NV_PREF_PLMN_I,
        /* Obsolete item                                                         */
        NV_DS_MIP_USER_PROF_VALID_I,
        /* Stores the NAI for 1xEV(HDR) Access Netword CHAP Authentication       */
        NV_HDR_AN_AUTH_NAI_I,
        /* Stores the password for 1xEV(HDR) Access Network CHAP Authentication  */
        NV_HDR_AN_AUTH_PASSWORD_I,                                            /*580*/
        /* If the PUZL is enabled or not                                         */
        NV_PUZL_ENABLED_I,
        /* Obsolete item                                                         */
        NV_PUZL_I,
        /* Session configuration for HDR KEP                                     */
        NV_HDRKEP_CONFIG_I,
        /* Session configuration for HDR AUTH                                    */
        NV_HDRAUTH_CONFIG_I,
        /* IM anti-jamming threshold data for the 4th stage                      */
        NV_IM_LEVEL3_I,
        /* IM anti-jamming threshold data for the 5th stage                      */
        NV_IM_LEVEL4_I,
        /* Minimum power output from the AGC accumulator                         */
        NV_AGC_VALUE_3_MIN_I,
        /* Minimum power output from the AGC accumulator                         */
        NV_AGC_VALUE_4_MIN_I,
        /* Gain attenuation limit                                                */
        NV_TX_GAIN_ATTEN_LIMIT_I,
        /* Falling threshold data for the third stage                            */
        NV_CDMA_LNA_3_FALL_I,                                                 /*590*/
        /* Offset Value subtracted from IF VGA linearizer table                  */
        NV_CDMA_LNA_3_OFFSET_I,
        /* Rising threshold data                                                 */
        NV_CDMA_LNA_3_RISE_I,
        /* Gain variations of the LNA                                            */
        NV_CDMA_LNA_3_OFFSET_VS_FREQ_I,
        /* Falling threshold data                                                */
        NV_PCS_LNA_3_FALL_I,
        /* Offset Value subtracted from IF VGA linearizer table                  */
        NV_PCS_LNA_3_OFFSET_I,
        /* Rising threshold data                                                 */
        NV_PCS_LNA_3_RISE_I,
        /* Gain variations of the LNA                                            */
        NV_PCS_LNA_3_OFFSET_VS_FREQ_I,
        /* Falling threshold data                                                */
        NV_CDMA_LNA_4_FALL_I,
        /* Offset Value subtracted from IF VGA linearizer table                  */
        NV_CDMA_LNA_4_OFFSET_I,
        /* Rising threshold data                                                 */
        NV_CDMA_LNA_4_RISE_I,                                                 /*600*/
        /* Gain variations of the LNA                                            */
        NV_CDMA_LNA_4_OFFSET_VS_FREQ_I,
        /* Falling threshold data                                                */
        NV_PCS_LNA_4_FALL_I,
        /* Offset Value subtracted from IF VGA linearizer table                  */
        NV_PCS_LNA_4_OFFSET_I,
        /* Rising threshold data                                                 */
        NV_PCS_LNA_4_RISE_I,
        /* Gain variations of the LNA                                            */
        NV_PCS_LNA_4_OFFSET_VS_FREQ_I,
        /* 2nd stage LNA falling threshold                                       */
        NV_DFM_LNA_FALL_I,
        /* 2nd stage LNA rising threshold offset                                 */
        NV_DFM_LNA_OFFSET_I,
        /* 1st stage LNA rising threshold                                        */
        NV_DFM_LNA_RISE_I,
        /* Offset value when the two-stage LNA is in its 2nd stage               */
        NV_DFM_LNA_OFFSET_VS_FREQ_I,
        /* 2nd stage LNA minimum AGC accumulator output                          */
        NV_DFM_AGC_ACC_MIN_1_I,                                               /*610*/
        /* AGC filter gain                                                       */
        NV_DFM_AGC_IM_GAIN_I,
        /* AGC filter gain                                                       */
        NV_DFM_AGC_DC_GAIN_I,
        /* 2 stage threshold data                                                */
        NV_DFM_IM_LEVEL1_I,
        /* No. of shifts to the input value of the fine-grained DC offset loop   */
        NV_GPS_FG_TRK_OFFSET_SCALER_I,
        /* No. of shifts to the input value of the fine-grained DC offset loop   */
        NV_DIGITAL_FG_TRK_OFFSET_SCALER_I,
        /* No. of shifts to the input value of the fine-grained DC offset loop   */
        NV_FM_FG_TRK_OFFSET_SCALER_I,
        /* Static phase offset for LNA gain step 0                               */
        NV_DFM_LNA_S0_PHASE_OFFSET_I,
        /* Static phase offset for LNA gain step 1                               */
        NV_DFM_LNA_S1_PHASE_OFFSET_I,
        /* I accumulator in the coarse-grain DC offset cancellation loop         */
        NV_CDMA_RXF_CG_IOFFSET_I,
        /* I accumulator in the coarse-grain DC offset cancellation loop         */
        NV_PCS_RXF_CG_IOFFSET_I,                                              /*620*/
        /* I accumulator in the coarse-grain DC offset cancellation loop         */
        NV_FM_RXF_CG_IOFFSET_I,
        /* I accumulator in the coarse-grain DC offset cancellation loop         */
        NV_GPS_RXF_CG_IOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_CDMA_RXF_CG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_PCS_RXF_CG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_FM_RXF_CG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_GPS_RXF_CG_QOFFSET_I,
        /* I accumulator in the fine-grain DC offset cancellation loop           */
        NV_CDMA_RXF_FG_IOFFSET_I,
        /* I accumulator in the fine-grain DC offset cancellation loop           */
        NV_PCS_RXF_FG_IOFFSET_I,
        /* I accumulator in the fine-grain DC offset cancellation loop           */
        NV_FM_RXF_FG_IOFFSET_I,
        /* I accumulator in the fine-grain DC offset cancellation loop           */
        NV_GPS_RXF_FG_IOFFSET_I,                                              /*630*/
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_CDMA_RXF_FG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_PCS_RXF_FG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_FM_RXF_FG_QOFFSET_I,
        /* Q accumulator in the coarse-grain DC offset cancellation loop         */
        NV_GPS_RXF_FG_QOFFSET_I,
        /* I accumulator in the estimator                                        */
        NV_CDMA_DACC_EST_IOFFSET_I,
        /* I accumulator in the estimator                                        */
        NV_PCS_DACC_EST_IOFFSET_I,
        /* I accumulator in the estimator                                        */
        NV_FM_DACC_EST_IOFFSET_I,
        /* I accumulator in the estimator                                        */
        NV_GPS_DACC_EST_IOFFSET_I,
        /* Q accumulator in the estimator                                        */
        NV_CDMA_DACC_EST_QOFFSET_I,
        /* Q accumulator in the estimator                                        */
        NV_PCS_DACC_EST_QOFFSET_I,                                            /*640*/
        /* Q accumulator in the estimator                                        */
        NV_FM_DACC_EST_QOFFSET_I,
        /* Q accumulator in the estimator                                        */
        NV_GPS_DACC_EST_QOFFSET_I,
        /* I accumulator associated with gain step 0 in the DAC Controller       */
        NV_CDMA_DACC_IACCUM0_I,
        /* I accumulator associated with gain step 0 in the DAC Controller       */
        NV_PCS_DACC_IACCUM0_I,
        /* I accumulator associated with gain step 0 in the DAC Controller       */
        NV_FM_DACC_IACCUM0_I,
        /* I accumulator associated with gain step 0 in the DAC Controller       */
        NV_GPS_DACC_IACCUM0_I,
        /* I accumulator associated with gain step 1 in the DAC Controller       */
        NV_CDMA_DACC_IACCUM1_I,
        /* I accumulator associated with gain step 1 in the DAC Controller       */
        NV_PCS_DACC_IACCUM1_I,
        /* I accumulator associated with gain step 1 in the DAC Controller       */
        NV_FM_DACC_IACCUM1_I,
        /* I accumulator associated with gain step 1 in the DAC Controller       */
        NV_GPS_DACC_IACCUM1_I,                                                /*650*/
        /* I accumulator associated with gain step 2 in the DAC Controller       */
        NV_CDMA_DACC_IACCUM2_I,
        /* I accumulator associated with gain step 2 in the DAC Controller       */
        NV_PCS_DACC_IACCUM2_I,
        /* I accumulator associated with gain step 2 in the DAC Controller       */
        NV_FM_DACC_IACCUM2_I,
        /* I accumulator associated with gain step 2 in the DAC Controller       */
        NV_GPS_DACC_IACCUM2_I,
        /* I accumulator associated with gain step 3 in the DAC Controller       */
        NV_CDMA_DACC_IACCUM3_I,
        /* I accumulator associated with gain step 3 in the DAC Controller       */
        NV_PCS_DACC_IACCUM3_I,
        /* I accumulator associated with gain step 3 in the DAC Controller       */
        NV_FM_DACC_IACCUM3_I,
        /* I accumulator associated with gain step 3 in the DAC Controller       */
        NV_GPS_DACC_IACCUM3_I,
        /* I accumulator associated with gain step 4 in the DAC Controller       */
        NV_CDMA_DACC_IACCUM4_I,
        /* I accumulator associated with gain step 4 in the DAC Controller       */
        NV_PCS_DACC_IACCUM4_I,                                                /*660*/
        /* I accumulator associated with gain step 4 in the DAC Controller       */
        NV_FM_DACC_IACCUM4_I,
        /* I accumulator associated with gain step 4 in the DAC Controller       */
        NV_GPS_DACC_IACCUM4_I,
        /* Q accumulator associated with gain step 0 in the DAC Controller       */
        NV_CDMA_DACC_QACCUM0_I,
        /* Q accumulator associated with gain step 0 in the DAC Controller       */
        NV_PCS_DACC_QACCUM0_I,
        /* Q accumulator associated with gain step 0 in the DAC Controller       */
        NV_FM_DACC_QACCUM0_I,
        /* Q accumulator associated with gain step 0 in the DAC Controller       */
        NV_GPS_DACC_QACCUM0_I,
        /* Q accumulator associated with gain step 1 in the DAC Controller       */
        NV_CDMA_DACC_QACCUM1_I,
        /* Q accumulator associated with gain step 1 in the DAC Controller       */
        NV_PCS_DACC_QACCUM1_I,
        /* Q accumulator associated with gain step 1 in the DAC Controller       */
        NV_FM_DACC_QACCUM1_I,
        /* Q accumulator associated with gain step 1 in the DAC Controller       */
        NV_GPS_DACC_QACCUM1_I,                                                /*670*/
        /* Q accumulator associated with gain step 2 in the DAC Controller       */
        NV_CDMA_DACC_QACCUM2_I,
        /* Q accumulator associated with gain step 2 in the DAC Controller       */
        NV_PCS_DACC_QACCUM2_I,
        /* Q accumulator associated with gain step 2 in the DAC Controller       */
        NV_FM_DACC_QACCUM2_I,
        /* Q accumulator associated with gain step 2 in the DAC Controller       */
        NV_GPS_DACC_QACCUM2_I,
        /* Q accumulator associated with gain step 3 in the DAC Controller       */
        NV_CDMA_DACC_QACCUM3_I,
        /* Q accumulator associated with gain step 3 in the DAC Controller       */
        NV_PCS_DACC_QACCUM3_I,
        /* Q accumulator associated with gain step 3 in the DAC Controller       */
        NV_FM_DACC_QACCUM3_I,
        /* Q accumulator associated with gain step 3 in the DAC Controller       */
        NV_GPS_DACC_QACCUM3_I,
        /* Q accumulator associated with gain step 4 in the DAC Controller       */
        NV_CDMA_DACC_QACCUM4_I,
        /* Q accumulator associated with gain step 4 in the DAC Controller       */
        NV_PCS_DACC_QACCUM4_I,                                                /*680*/
        /* Q accumulator associated with gain step 4 in the DAC Controller       */
        NV_FM_DACC_QACCUM4_I,
        /* Q accumulator associated with gain step 4 in the DAC Controller       */
        NV_GPS_DACC_QACCUM4_I,
        /* Gain value used to scale the estimator accumulator by before updating */
        NV_CDMA_DACC_GAIN_MULT_I,
        /* Gain value used to scale the estimator accumulator by before updating */
        NV_PCS_DACC_GAIN_MULT_I,
        /* Gain value used to scale the estimator accumulator by before updating */
        NV_FM_DACC_GAIN_MULT_I,
        /* Gain value used to scale the estimator accumulator by before updating */
        NV_GPS_DACC_GAIN_MULT_I,
        /* IM2 cal items generated during RF Cal to be loaded into RFR6000       */
        NV_CDMA_IM2_I_VALUE_I,
        /* IM2 cal items generated during RF Cal to be loaded into RFR6000       */
        NV_PCS_IM2_I_VALUE_I,
        /* IM2 cal items generated during RF Cal to be loaded into RFR6000       */
        NV_CDMA_IM2_Q_VALUE_I,
        /* IM2 cal items generated during RF Cal to be loaded into RFR6000       */
        NV_PCS_IM2_Q_VALUE_I,                                                 /*690*/
        /* To correct for the deviations in the 32,768Hz crystal oscillator freq */
        NV_RTC_TIME_ADJUST_I,
        /* 13-bit two's complement integer for FM VGA gain offset                */
        NV_FM_VGA_GAIN_OFFSET_I,
        /* 13-bit two's complement integer for CDMA VGA gain offset              */
        NV_CDMA_VGA_GAIN_OFFSET_I,
        /* 13-bit two's complement integer for PCS VGA gain offset               */
        NV_PCS_VGA_GAIN_OFFSET_I,
        /* FM VGA gain offset variations over the frequencies                    */
        NV_FM_VGA_GAIN_OFFSET_VS_FREQ_I,
        /* CDMA VGA gain offset variations over the frequencies                  */
        NV_CDMA_VGA_GAIN_OFFSET_VS_FREQ_I,
        /* PCS VGA gain offset variations over the frequencies                   */
        NV_PCS_VGA_GAIN_OFFSET_VS_FREQ_I,
        /* FM VGA gain offset variations over the temperatures                   */
        NV_FM_VGA_GAIN_OFFSET_VS_TEMP_I,
        /* CDMA VGA gain offset variations over the temperatures                 */
        NV_CDMA_VGA_GAIN_OFFSET_VS_TEMP_I,
        /* PCS VGA gain offset variations over the temperatures                  */
        NV_PCS_VGA_GAIN_OFFSET_VS_TEMP_I,                                     /*700*/
        /* In-phase coefficient for mismatch compensation                        */
        NV_FM_MIS_COMP_A_OFFSET_I,
        /* In-phase coefficient for mismatch compensation                        */
        NV_DIGITAL_MIS_COMP_A_OFFSET_I,
        /* In-phase coefficient for mismatch compensation                        */
        NV_GPS_MIS_COMP_A_OFFSET_I,
        /* In-phase coefficient for mismatch compensation                        */
        NV_FM_MIS_COMP_B_OFFSET_I,
        /* In-phase coefficient for mismatch compensation                        */
        NV_DIGITAL_MIS_COMP_B_OFFSET_I,
        /* In-phase coefficient for mismatch compensation                        */
        NV_GPS_MIS_COMP_B_OFFSET_I,
        /* Send RRQ only if there was traffic since previous RRQ                 */
        NV_DS_MIP_RRQ_IF_TFRK_I,
        /* Collocated HDR disallowed time                                        */
        NV_COLLOC_DISALLOWED_TIME_I,
        /* Hold HDR time                                                         */
        NV_HOLD_HDR_TIME_I,
        /* Number of times NV value updated via IIR filter                       */
        NV_LO_BIAS_UPDATE_CNT_I,                                              /*710*/
        /* Spare item for developer                                              */
        NV_SPARE_3_I,
        /* Stores HDR Access Network Authentication Status.                      */
        NV_HDRSCP_AN_AUTH_STATUS_I,
        /*Used to allow a user to Save an IMSI as an Index in NV */
        NV_IMSI_INDEX_I,
        /* Enable or disable a user profile. Each element can be 1 or 0 indicating 
          whether the profile is enabled or disabled respectively..              */
        NV_DS_MIP_ENABLE_PROF_I,
        /*Contains 8-bit IM anti-jamming threshold data for the fourth 
         stage in two 's complement format when the five-stage LNA is 
         in its NONBYPASS_HOLD STATEs.*/
        NV_PCS_IM_LEVEL3_I,
        /* contains 8-bit IM anti-jamming threshold data for the fifth
         stage in two 's complement format when the five-stage LNA is 
         in NONBYPASS_HOLD STATEs. */
        NV_PCS_IM_LEVEL4_I,
        /*provides the minimum power output from the AGC accumulator 
         when AGC_VALUE_MIN_EN is enabled and the five-stage LNA is 
         in its forth stage. */
        NV_PCS_AGC_VALUE_3_MIN_I,
        /*provides the minimum power output from the AGC accumulator
        when AGC_VALUE_MIN_EN is enabled and the five-stage LNA is in
        its fifth stage. */
        NV_PCS_AGC_VALUE_4_MIN_I,

        /* SMP - Time at which keep alive timer was started                      */
        NV_HDRSMPKA_START_TIME_I,

        /* SMP - Time at which keep alive message was last sent             720  */
        NV_HDRSMPKA_SENT_TIME_I,

        /* Supplement item to the item NV_SMS_BC_SERVICE_TABLE_I */
        NV_SMS_BC_SERVICE_TABLE_OPTIONS_I,

        NV_ACQ_DB_I = 722,
        NV_ACQ_LIST_I = 723,
        NV_GSM_CAL_ARFCN_I = 724,
        NV_DCS_CAL_ARFCN_I = 725,
        NV_GSM_RX_GAIN_RANGE_1_FREQ_COMP_I = 726,
        NV_GSM_RX_GAIN_RANGE_2_FREQ_COMP_I = 727,
        NV_GSM_RX_GAIN_RANGE_3_FREQ_COMP_I = 728,
        NV_GSM_RX_GAIN_RANGE_4_FREQ_COMP_I = 729,
        NV_DCS_RX_GAIN_RANGE_1_FREQ_COMP_I = 730,
        NV_DCS_RX_GAIN_RANGE_2_FREQ_COMP_I = 731,
        NV_DCS_RX_GAIN_RANGE_3_FREQ_COMP_I = 732,
        NV_DCS_RX_GAIN_RANGE_4_FREQ_COMP_I = 733,
        NV_TRK_LO_ADJ_PDM_INIT_VAL_I = 734,
        NV_GSM_TRK_LO_ADJ_PDM_GAIN_SLOPE_I = 735,
        /* Calibrated standard deviation of this phone's doppler estimator in Hz */
        NV_GPS_DOPP_SDEV_I,
        /* Acquisition List                                                      */
        NV_ACQ_LIST_2_I,
        /* Acquisition List                                                      */
        NV_ACQ_LIST_3_I,
        /* Acquisition List                                                      */
        NV_ACQ_LIST_4_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_00_I,                                   /*740*/
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_01_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_02_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_03_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_04_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_05_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_06_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_07_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_08_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_09_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_10_I,                                   /*750*/
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_11_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_12_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_13_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_UP_INDEX_14_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_00_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_01_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_02_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_03_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_04_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_05_I,                                 /*760*/
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_06_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_07_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_08_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_09_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_10_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_11_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_12_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_13_I,
        /* PA DAC value                                                          */
        NV_GSM_TX_BURST_RAMP_DOWN_INDEX_14_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_00_I,                                   /*770*/
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_01_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_02_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_03_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_04_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_05_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_06_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_07_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_08_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_09_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_10_I,                                   /*780*/
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_11_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_12_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_13_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_14_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_UP_INDEX_15_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_00_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_01_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_02_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_03_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_04_I,                                 /*790*/
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_05_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_06_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_07_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_08_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_09_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_10_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_11_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_12_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_13_I,
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_14_I,                                 /*800*/
        /* PA DAC value                                                          */
        NV_DCS_TX_BURST_RAMP_DOWN_INDEX_15_I,
        /* PA DAC counts per dB                                                  */
        NV_GSM_PA_GAIN_SLOPE_I,
        /* PA DAC counts per dB                                                  */
        NV_DCS_PA_GAIN_SLOPE_I,
        /* 1/16 dB                                                               */
        NV_GSM_TX_FREQ_COMP_I,
        /* 1/16 dB                                                               */
        NV_DCS_TX_FREQ_COMP_I,
        /* 1/16 dB per volt                                                      */
        NV_GSM_VBATT_HI_PA_COMP_I,
        /* 1/16 dB per volt                                                      */
        NV_GSM_VBATT_LO_PA_COMP_I,
        /* 1/16 dB per volt                                                      */
        NV_DCS_VBATT_HI_PA_COMP_I,
        /* 1/16 dB per volt                                                      */
        NV_DCS_VBATT_LO_PA_COMP_I,
        /* PA DAC value                                                          */
        NV_VBATT_3200_MV_ADC_I,                                               /*810*/
        /* PA DAC value                                                          */
        NV_VBATT_3700_MV_ADC_I,
        /* PA DAC value                                                          */
        NV_VBATT_4200_MV_ADC_I,
        /* PA DAC value                                                          */
        NV_GSM_PRECHARGE_I,
        /* PA DAC value                                                          */
        NV_DCS_PRECHARGE_I,
        /* Quarter-symbol                                                        */
        NV_GSM_PRECHARGE_DUR_I,
        /* Quarter-symbol                                                        */
        NV_DCS_PRECHARGE_DUR_I,
        /* Timer value to wait until checking the state of LOCK_DET              */
        NV_DIGITAL_PLL_LOCK_TIMER_I,
        /* HDR rx diversity control parameter                                    */
        NV_HDR_RX_DIVERSITY_CTRL_I,
        /* Quarter-symbol                                                        */
        NV_GSM_PA_START_TIME_OFFSET_I,
        /* Quarter-symbol                                                        */
        NV_GSM_PA_STOP_TIME_OFFSET_I,                                         /*820*/
        /* Quarter-symbol                                                        */
        NV_DCS_PA_START_TIME_OFFSET_I,
        /* Quarter-symbol                                                        */
        NV_DCS_PA_STOP_TIME_OFFSET_I,
        /* Position Location Privacy                                             */
        NV_GPS1_PRIVACY_I,
        /* Position Location Network Access Control                              */
        NV_GPS1_NET_ACCESS_I,
        /* Enables/Disables Cell Based Position Determination                    */
        NV_GPS1_CELLBASED_SMS_I,
        /* Enables/Disables Cell Based Position Determination                    */
        NV_GPS1_TELESERVICE_ID_I,
        /* HDR Search Parameters                                                 */
        NV_HDRRUP_SRCH_PARAMS_I,
        /* Bypass timer value when LNA is in BYPASS_HOLD_STATE                   */
        NV_DFM_LNA_BYPASS_TIMER_I,
        /* Bypass timer value when LNA is in NONBYPASS_HOLD_STATE                */
        NV_DFM_LNA_NONBYPASS_TIMER_I,
        /* Storage for GSM/WCDMA SMS routing configuration                       */
        NV_SMS_CFG_ROUTING_I,                                                 /*830*/
        /* Data Burst Packet Size supported by this network                      */
        NV_GPS1_NET_DBM_SIZE_I,
        /* Stop monitoring 1x page while in HDR data call                        */
        NV_HDR_DO_NOT_DISTURB_I,
        /* Transmitter Gain Attenuation Limit                                    */
        NV_CDMA_TX_GAIN_ATTEN_LIMIT_I,
        /* Transmitter Gain Attenuation Limit                                    */
        NV_PCS_TX_GAIN_ATTEN_LIMIT_I,
        /* Transmitter Gain Attenuation Limit                                    */
        NV_AMPS_TX_GAIN_ATTEN_LIMIT_I,
        /* Transmitter Gain Attenuation Limit                                    */
        NV_GPS_TX_GAIN_ATTEN_LIMIT_I,
        /* ZIFRIC register value that controls IM2 transconductance              */
        NV_CDMA_IM2_TRANSCONDUCTOR_VALUE_I,
        /* ZIFRIC register value that controls IM2 transconductance              */
        NV_PCS_IM2_TRANSCONDUCTOR_VALUE_I,
        /* Bypass timer value                                                    */
        NV_LNA_NON_BYPASS_TIMER_0_I,
        /* Bypass timer value                                                    */
        NV_LNA_NON_BYPASS_TIMER_1_I,                                          /*840*/
        /* Bypass timer value                                                    */
        NV_LNA_NON_BYPASS_TIMER_2_I,
        /* Bypass timer value                                                    */
        NV_LNA_NON_BYPASS_TIMER_3_I,
        /* Bypass timer value                                                    */
        NV_LNA_BYPASS_TIMER_0_I,
        /* Bypass timer value                                                    */
        NV_LNA_BYPASS_TIMER_1_I,
        /* Bypass timer value                                                    */
        NV_LNA_BYPASS_TIMER_2_I,
        /* Bypass timer value                                                    */
        NV_LNA_BYPASS_TIMER_3_I,
        /* CDMA SMS Parameters/templates                                         */
        NV_SMS_CD_PARMS_I,
        NV_ACQ_ORDER_PREF_I = 848,
        NV_NET_SEL_MODE_PREF_I = 849,
        NV_SERVICE_DOMAIN_PREF_I = 850,
        NV_PPP_AUTHENTICATION_I = 851,
        NV_APN_NAME_I = 852,
        NV_EQUIVALENT_PLMN_LIST_I = 853,
        /* Public Key Organization Identifier                                    */
        NV_DS_MIP_DMU_PKOID_I,
        /* RTRE configuration                                                    */
        NV_RTRE_CONFIG_I,
        /* RX AGC offset for each VGA gain                                       */
        NV_WCDMA_VGA_GAIN_OFFSET_I,
        /* RX AGC offset for each VGA gain based on frequency                    */
        NV_WCDMA_VGA_GAIN_OFFSET_VS_FREQ_I,
        /* RX AGC offset for each VGA gain based on temperature                  */
        NV_WCDMA_VGA_GAIN_OFFSET_VS_TEMP_I,
        /* LNA threshold from mid to low state                                   */
        NV_WCDMA_LNA_RANGE_RISE_2_I,
        /* Mixer threshold from high to low state                                */
        NV_WCDMA_LNA_RANGE_RISE_3_I,                                          /*860*/
        /* LNA threshold from low to mid state                                   */
        NV_WCDMA_LNA_RANGE_FALL_2_I,
        /* Mixer threshold from low to high state                                */
        NV_WCDMA_LNA_RANGE_FALL_3_I,
        /* IM threshold for LNA mid to low state                                 */
        NV_WCDMA_IM_LEVEL_2_I,
        /* Mixer threshold for high to low state                                 */
        NV_WCDMA_IM_LEVEL_3_I,
        /* LNA gain step from mid to low state                                   */
        NV_WCDMA_LNA_RANGE_OFFSET_2_I,
        /* Mixer gain step from high to low state                                */
        NV_WCDMA_LNA_RANGE_OFFSET_3_I,
        /* LNA gain step from mid to low state based on frequency                */
        NV_WCDMA_LNA_OFFSET_VS_FREQ_2_I,
        /* Mixer gain step from high to low state based on frequency             */
        NV_WCDMA_LNA_OFFSET_VS_FREQ_3_I,
        /* I cancellation value for lower in-band jammer                         */
        NV_WCDMA_IM2_I_VALUE_I,
        /* Q cancellation value for lower in-band jammer                         */
        NV_WCDMA_IM2_Q_VALUE_I,                                               /*870*/
        /* Transconductor value for lower in-band jammer                         */
        NV_WCDMA_IM2_TRANSCONDUCTOR_VALUE_I,
        /* Linearizer underflow for LNA low gain state and Mixer High gainstate  */
        NV_WCDMA_RX_AGC_MIN_2_I,
        /* Linearizer underflow for LNA Low gain state and Mixer Low gain state  */
        NV_WCDMA_RX_AGC_MIN_3_I,
        /* VBATT min and max voltage value                                       */
        NV_WCDMA_VBATT_I,
        /* THERM min and max voltage value                                       */
        NV_WCDMA_THERM_I,
        /* WCDMA UE Maximum TX power in dbm                                      */
        NV_WCDMA_MAX_TX_POWER_I,
        /* The FM MAC level that the PA will switch from low to high gain        */
        NV_FM_PA_MAC_HIGH_I,
        /* Selects dynamic range in Rx Front.                                    */
        NV_CDMA_DYNAMIC_RANGE_I,
        /* Min Rx RSSI in 1/10 dB increments.                                    */
        NV_CDMA_MIN_RX_RSSI_I,
        /* Enables Integrity Protection feature in the UE                        */
        NV_RRC_INTEGRITY_ENABLED_I,                                           /*880*/
        /* Enables Ciphering feature in the UE                                   */
        NV_RRC_CIPHERING_ENABLED_I,
        /* Fake Security turned on/off in the UE                                 */
        NV_RRC_FAKE_SECURITY_ENABLED_I,
        /* This NV item records the # of CDMA powerup registration performed.    */
        NV_CDMA_POWERUP_REG_PERFORMED_I,
        /* Defines the Tx Warmup duration                                        */
        NV_TX_WARMUP_I,
        NV_LAST_TX_DATA_COUNT_I = 885,
        NV_LAST_RX_DATA_COUNT_I = 886,
        NV_TOTAL_TX_DATA_COUNT_I = 887,
        NV_TOTAL_RX_DATA_COUNT_I = 888,
        /* Mobile Node Authenticator                                             */
        NV_DS_MIP_DMU_MN_AUTH_I,
        /* Configurable USB product id offset                                    */
        NV_USB_PRODUCT_ID_OFFSET_I,                                           /*890*/
        /* Call duration                                                         */
        NV_AVCD_CALL_DURATION_I,
        /* Time between calls                                                    */
        NV_AVCD_TIME_BETWEEN_CALLS_I,
        /* Number of calls                                                       */
        NV_AVCD_NUMBER_OF_CALLS_I,
        /* Service options                                                       */
        NV_AVCD_SO_I,
        /* Minimum value before searcher declares  OUT_OF_SERVICE_AREA           */
        NV_WCDMA_OUT_OF_SERVICE_THRESH_I,
        /* Indicates which class to use for the first UIM instruction.           */
        NV_UIM_FIRST_INST_CLASS_I,
        /* HDR Set Management Parameters Override Allowed.                       */
        NV_HDRRUP_OVERRIDE_ALLOWED_I,
        /* M511 mode setting                                                     */
        NV_JCDMA_M511_MODE_I,
        /* M512 mode setting                                                     */
        NV_JCDMA_M512_MODE_I,
        /* M513 mode setting                                                     */
        NV_JCDMA_M513_MODE_I,                                                      /*900*/

        NV_BAND_PREF_16_31 = 946,
        NV_C1_CDMA_LNA_OFFSET_I = 948,
        NV_C1_CDMA_LNA_OFFSET_VS_FREQ_I = 949,
        NV_C1_PCS_LNA_OFFSET_I = 950,
        NV_C1_PCS_LNA_OFFSET_VS_FREQ_I = 951,
        NV_C1_CDMA_LNA_2_OFFSET_I = 952,
        NV_C1_CDMA_LNA_2_OFFSET_VS_FREQ_I = 953,
        NV_C1_PCS_LNA_2_OFFSET_I = 954,
        NV_C1_PCS_LNA_2_OFFSET_VS_FREQ_I = 955,
        NV_C1_CDMA_LNA_3_OFFSET_I = 956,
        NV_C1_CDMA_LNA_3_OFFSET_VS_FREQ_I = 957,
        NV_C1_PCS_LNA_3_OFFSET_I = 958,
        NV_C1_PCS_LNA_3_OFFSET_VS_FREQ_I = 959,
        NV_C1_CDMA_LNA_4_OFFSET_I = 960,
        NV_C1_CDMA_LNA_4_OFFSET_VS_FREQ_I = 961,
        NV_C1_PCS_LNA_4_OFFSET_I = 962,
        NV_C1_PCS_LNA_4_OFFSET_VS_FREQ_I = 963,



        NV_C1_CDMA_VGA_GAIN_OFFSET_I = 974,
        NV_C1_CDMA_VGA_GAIN_OFFSET_VS_FREQ_I = 975,
        NV_C1_CDMA_VGA_GAIN_OFFSET_VS_TEMP_I = 976,
        NV_C1_PCS_VGA_GAIN_OFFSET_I = 977,
        NV_C1_PCS_VGA_GAIN_OFFSET_VS_FREQ_I = 978,
        NV_C1_PCS_VGA_GAIN_OFFSET_VS_TEMP_I = 979,
        NV_C1_DIGITAL_MIS_COMP_A_OFFSET_I = 980,
        NV_C1_DIGITAL_MIS_COMP_B_OFFSET_I = 982,

        NV_CDMA_RX_DIVERSITY_CTRL_I = 1018,
        NV_C1_CDMA_IM2_Q_VALUE_I = 1020,
        NV_C1_PCS_IM2_Q_VALUE_I = 1021,
        NV_C1_CDMA_IM2_I_VALUE_I = 1022,
        NV_C1_PCS_IM2_I_VALUE_I = 1023,
        NV_C1_CDMA_IM2_TRANSCONDUCTOR_VALUE_I = 1024,
        NV_C1_PCS_IM2_TRANSCONDUCTOR_VALUE_I = 1025,

        NV_GPS_RF_CONFIG_I = 1032,
        NV_C1_CDMA_LNA_1_RISE_I = 1033,
        NV_C1_CDMA_LNA_2_RISE_I = 1034,
        NV_C1_CDMA_LNA_3_RISE_I = 1035,
        NV_C1_CDMA_LNA_4_RISE_I = 1036,
        NV_C1_PCS_LNA_1_RISE_I = 1037,
        NV_C1_PCS_LNA_2_RISE_I = 1038,
        NV_C1_PCS_LNA_3_RISE_I = 1039,
        NV_C1_PCS_LNA_4_RISE_I = 1040,
        NV_C1_CDMA_LNA_1_FALL_I = 1041,
        NV_C1_CDMA_LNA_2_FALL_I = 1042,
        NV_C1_CDMA_LNA_3_FALL_I = 1043,
        NV_C1_CDMA_LNA_4_FALL_I = 1044,
        NV_C1_PCS_LNA_1_FALL_I = 1045,
        NV_C1_PCS_LNA_2_FALL_I = 1046,
        NV_C1_PCS_LNA_3_FALL_I = 1047,
        NV_C1_PCS_LNA_4_FALL_I = 1048,
        NV_C1_CDMA_IM_LEVEL1_I = 1049,
        NV_C1_CDMA_IM_LEVEL2_I = 1050,
        NV_C1_CDMA_IM_LEVEL3_I = 1051,
        NV_C1_CDMA_IM_LEVEL4_I = 1052,
        NV_C1_PCS_IM_LEVEL1_I = 1053,
        NV_C1_PCS_IM_LEVEL2_I = 1054,
        NV_C1_PCS_IM_LEVEL3_I = 1055,
        NV_C1_PCS_IM_LEVEL4_I = 1056,



        NV_BC0_ENC_BTF_I = 1734,
        NV_BC0_EXP_HDET_VS_AGC_I = 1733,
        NV_BC0_HDET_OFF_I = 1731,
        NV_BC0_HDET_SPN_I = 1732,
        NV_BC0_P1_RISE_FALL_OFF_I = 1736,
        NV_BC0_PA_R1_FALL_I = 1726,
        NV_BC0_PA_R1_RISE_I = 1725,
        NV_BC0_PA_R2_FALL_I = 1728,
        NV_BC0_PA_R2_RISE_I = 1727,
        NV_BC0_PA_R3_FALL_I = 1730,
        NV_BC0_PA_R3_RISE_I = 1729,
        NV_BC0_TX_COMP0_I = 1720,
        NV_BC0_TX_COMP1_I = 1721,
        NV_BC0_TX_COMP2_I = 1722,
        NV_BC0_TX_COMP3_I = 1723,
        NV_BC0_TX_LIM_VS_FREQ_I = 1724,
        NV_BC0_TX_LIM_VS_TEMP_I = 1715,
        NV_BC0_TX_LIN_MASTER0_I = 1716,
        NV_BC0_TX_LIN_MASTER1_I = 1717,
        NV_BC0_TX_LIN_MASTER2_I = 1718,
        NV_BC0_TX_LIN_MASTER3_I = 1719,
        NV_BC0_VCO_COARSE_TUNE_TABLE_I = 1735,
        NV_BC1_ENC_BTF_I = 1645,
        NV_BC1_EXP_HDET_VS_AGC_I = 1644,
        NV_BC1_HDET_OFF_I = 1642,
        NV_BC1_HDET_SPN_I = 1643,
        NV_BC1_P1_RISE_FALL_OFF_I = 1647,
        NV_BC1_PA_R1_FALL_I = 1637,
        NV_BC1_PA_R1_RISE_I = 1636,
        NV_BC1_PA_R2_FALL_I = 1639,
        NV_BC1_PA_R2_RISE_I = 1638,
        NV_BC1_PA_R3_FALL_I = 1641,
        NV_BC1_PA_R3_RISE_I = 1640,
        NV_BC1_TX_COMP0_I = 1631,
        NV_BC1_TX_COMP1_I = 1632,
        NV_BC1_TX_COMP2_I = 1633,
        NV_BC1_TX_COMP3_I = 1634,
        NV_BC1_TX_LIM_VS_FREQ_I = 1635,
        NV_BC1_TX_LIM_VS_TEMP_I = 1626,
        NV_BC1_TX_LIN_MASTER0_I = 1627,
        NV_BC1_TX_LIN_MASTER1_I = 1628,
        NV_BC1_TX_LIN_MASTER2_I = 1629,
        NV_BC1_TX_LIN_MASTER3_I = 1630,
        NV_BC1_VCO_COARSE_TUNE_TABLE_I = 1646,
        NV_BC3_ENC_BTF_I = 1567,
        NV_BC3_EXP_HDET_VS_AGC_I = 1566,
        NV_BC3_HDET_OFF_I = 1564,
        NV_BC3_HDET_SPN_I = 1565,
        NV_BC3_P1_RISE_FALL_OFF_I = 1569,
        NV_BC3_PA_R1_FALL_I = 1559,
        NV_BC3_PA_R1_RISE_I = 1558,
        NV_BC3_PA_R2_FALL_I = 1561,
        NV_BC3_PA_R2_RISE_I = 1560,
        NV_BC3_PA_R3_FALL_I = 1563,
        NV_BC3_PA_R3_RISE_I = 1562,
        NV_BC3_TX_COMP0_I = 1552,
        NV_BC3_TX_COMP1_I = 1553,
        NV_BC3_TX_COMP2_I = 1554,
        NV_BC3_TX_COMP3_I = 1555,
        NV_BC3_TX_LIM_VS_FREQ_I = 1557,
        NV_BC3_TX_LIM_VS_TEMP_I = 1547,
        NV_BC3_TX_LIN_MASTER0_I = 1548,
        NV_BC3_TX_LIN_MASTER1_I = 1549,
        NV_BC3_TX_LIN_MASTER2_I = 1550,
        NV_BC3_TX_LIN_MASTER3_I = 1551,
        NV_BC3_VCO_COARSE_TUNE_TABLE_I = 1568,
        NV_BC4_ENC_BTF_I = 1488,
        NV_BC4_EXP_HDET_VS_AGC_I = 1487,
        NV_BC4_HDET_OFF_I = 1485,
        NV_BC4_HDET_SPN_I = 1486,
        NV_BC4_P1_RISE_FALL_OFF_I = 1490,
        NV_BC4_PA_R1_FALL_I = 1480,
        NV_BC4_PA_R1_RISE_I = 1479,
        NV_BC4_PA_R2_FALL_I = 1482,
        NV_BC4_PA_R2_RISE_I = 1481,
        NV_BC4_PA_R3_FALL_I = 1484,
        NV_BC4_PA_R3_RISE_I = 1483,
        NV_BC4_TX_COMP0_I = 1474,
        NV_BC4_TX_COMP1_I = 1475,
        NV_BC4_TX_COMP2_I = 1476,
        NV_BC4_TX_COMP3_I = 1477,
        NV_BC4_TX_LIM_VS_FREQ_I = 1478,
        NV_BC4_TX_LIM_VS_TEMP_I = 1469,
        NV_BC4_TX_LIN_MASTER0_I = 1470,
        NV_BC4_TX_LIN_MASTER1_I = 1471,
        NV_BC4_TX_LIN_MASTER2_I = 1472,
        NV_BC4_TX_LIN_MASTER3_I = 1473,
        NV_BC4_VCO_COARSE_TUNE_TABLE_I = 1489,
        NV_BC5_ENC_BTF_I = 1410,
        NV_BC5_EXP_HDET_VS_AGC_I = 1409,
        NV_BC5_HDET_OFF_I = 1407,
        NV_BC5_HDET_SPN_I = 1408,
        NV_BC5_P1_RISE_FALL_OFF_I = 1412,
        NV_BC5_PA_R1_FALL_I = 1402,
        NV_BC5_PA_R1_RISE_I = 1401,
        NV_BC5_PA_R2_FALL_I = 1404,
        NV_BC5_PA_R2_RISE_I = 1403,
        NV_BC5_PA_R3_FALL_I = 1406,
        NV_BC5_PA_R3_RISE_I = 1405,
        NV_BC5_TX_COMP0_I = 1396,
        NV_BC5_TX_COMP1_I = 1397,
        NV_BC5_TX_COMP2_I = 1398,
        NV_BC5_TX_COMP3_I = 1399,
        NV_BC5_TX_LIM_VS_FREQ_I = 1400,
        NV_BC5_TX_LIM_VS_TEMP_I = 1391,
        NV_BC5_TX_LIN_MASTER0_I = 1392,
        NV_BC5_TX_LIN_MASTER1_I = 1393,
        NV_BC5_TX_LIN_MASTER2_I = 1394,
        NV_BC5_TX_LIN_MASTER3_I = 1395,
        NV_BC5_VCO_COARSE_TUNE_TABLE_I = 1411,
        NV_BC6_ENC_BTF_I = 1240,
        NV_BC6_EXP_HDET_VS_AGC_I = 1217,
        NV_BC6_HDET_OFF_I = 1218,
        NV_BC6_HDET_SPN_I = 1219,
        NV_BC6_LNA_1_FALL_I = 1224,
        NV_BC6_LNA_1_RISE_I = 1223,
        NV_BC6_LNA_2_FALL_I = 1228,
        NV_BC6_LNA_2_RISE_I = 1227,
        NV_BC6_LNA_3_FALL_I = 1242,
        NV_BC6_LNA_3_OFFSET_I = 1244,
        NV_BC6_LNA_3_RISE_I = 1243,
        NV_BC6_LNA_4_FALL_I = 1247,
        NV_BC6_LNA_4_RISE_I = 1248,
        NV_BC6_LNA_RANGE_12_OFFSET_I = 1229,
        NV_BC6_LNA_RANGE_POL_I = 1222,
        NV_BC6_P1_RISE_FALL_OFF_I = 1261,
        NV_BC6_PA_R1_FALL_I = 1221,
        NV_BC6_PA_R1_RISE_I = 1220,
        NV_BC6_PA_R2_FALL_I = 1356,
        NV_BC6_PA_R2_RISE_I = 1355,
        NV_BC6_PA_R3_FALL_I = 1358,
        NV_BC6_PA_R3_RISE_I = 1357,
        NV_BC6_TX_COMP0_I = 1214,
        NV_BC6_TX_COMP1_I = 1215,
        NV_BC6_TX_COMP2_I = 1353,
        NV_BC6_TX_COMP3_I = 1354,
        NV_BC6_TX_LIM_VS_FREQ_I = 1216,
        NV_BC6_TX_LIM_VS_TEMP_I = 1210,
        NV_BC6_TX_LIN_MASTER0_I = 1212,
        NV_BC6_TX_LIN_MASTER1_I = 1213,
        NV_BC6_TX_LIN_MASTER2_I = 1351,
        NV_BC6_TX_LIN_MASTER3_I = 1352,
        NV_BC6_VCO_COARSE_TUNE_TABLE_I = 1272,
        NV_BC6_GPS1_RF_DELAY_I = 1349,
        NV_BC5_GPS1_RF_DELAY_I = 1389,
        NV_BC4_GPS1_RF_DELAY_I = 1467,
        NV_BC3_GPS1_RF_DELAY_I = 1545,
        NV_BC1_GPS1_RF_DELAY_I = 1624,
        NV_BC0_GPS1_RF_DELAY_I = 1713,
        NV_C0_BC0_IM_LEVEL1_I = 1760,
        NV_C0_BC0_IM_LEVEL2_I = 1761,
        NV_C0_BC0_IM_LEVEL3_I = 1762,
        NV_C0_BC0_IM_LEVEL4_I = 1763,
        NV_C0_BC0_IM2_I_VALUE_I = 1747,
        NV_C0_BC0_IM2_Q_VALUE_I = 1748,
        NV_C0_BC0_IM2_TRANSCONDUCTOR_VALUE_I = 1751,
        NV_C0_BC0_LNA_1_FALL_I = 1753,
        NV_C0_BC0_LNA_1_OFFSET_I = 1743,
        NV_C0_BC0_LNA_1_OFFSET_VS_FREQ_I = 1739,
        NV_C0_BC0_LNA_1_RISE_I = 1752,
        NV_C0_BC0_LNA_2_FALL_I = 1755,
        NV_C0_BC0_LNA_2_OFFSET_I = 1744,
        NV_C0_BC0_LNA_2_OFFSET_VS_FREQ_I = 1740,
        NV_C0_BC0_LNA_2_RISE_I = 1754,
        NV_C0_BC0_LNA_3_FALL_I = 1757,
        NV_C0_BC0_LNA_3_OFFSET_I = 1745,
        NV_C0_BC0_LNA_3_OFFSET_VS_FREQ_I = 1741,
        NV_C0_BC0_LNA_3_RISE_I = 1756,
        NV_C0_BC0_LNA_4_FALL_I = 1759,
        NV_C0_BC0_LNA_4_OFFSET_I = 1746,
        NV_C0_BC0_LNA_4_OFFSET_VS_FREQ_I = 1742,
        NV_C0_BC0_LNA_4_RISE_I = 1758,
        NV_C0_BC0_TX_CAL_CHAN_I = 1737,
        NV_C0_BC0_RX_CAL_CHAN_I = 1738,
        NV_C0_BC0_VGA_GAIN_OFFSET_I = 1749,
        NV_C0_BC0_VGA_GAIN_OFFSET_VS_FREQ_I = 1750,
        NV_C0_BC1_IM_LEVEL1_I = 1681,
        NV_C0_BC1_IM_LEVEL2_I = 1682,
        NV_C0_BC1_IM_LEVEL3_I = 1683,
        NV_C0_BC1_IM_LEVEL4_I = 1684,
        NV_C0_BC1_IM2_I_VALUE_I = 1668,
        NV_C0_BC1_IM2_Q_VALUE_I = 1669,
        NV_C0_BC1_IM2_TRANSCONDUCTOR_VALUE_I = 1672,
        NV_C0_BC1_LNA_1_FALL_I = 1674,
        NV_C0_BC1_LNA_1_OFFSET_I = 1654,
        NV_C0_BC1_LNA_1_OFFSET_VS_FREQ_I = 1650,
        NV_C0_BC1_LNA_1_RISE_I = 1673,
        NV_C0_BC1_LNA_2_FALL_I = 1676,
        NV_C0_BC1_LNA_2_OFFSET_I = 1655,
        NV_C0_BC1_LNA_2_OFFSET_VS_FREQ_I = 1651,
        NV_C0_BC1_LNA_2_RISE_I = 1675,
        NV_C0_BC1_LNA_3_FALL_I = 1678,
        NV_C0_BC1_LNA_3_OFFSET_I = 1666,
        NV_C0_BC1_LNA_3_OFFSET_VS_FREQ_I = 1652,
        NV_C0_BC1_LNA_3_RISE_I = 1677,
        NV_C0_BC1_LNA_4_FALL_I = 1680,
        NV_C0_BC1_LNA_4_OFFSET_I = 1667,
        NV_C0_BC1_LNA_4_OFFSET_VS_FREQ_I = 1653,
        NV_C0_BC1_LNA_4_RISE_I = 1679,
        NV_C0_BC1_TX_CAL_CHAN_I = 1648,
        NV_C0_BC1_RX_CAL_CHAN_I = 1649,
        NV_C0_BC1_VGA_GAIN_OFFSET_I = 1670,
        NV_C0_BC1_VGA_GAIN_OFFSET_VS_FREQ_I = 1671,
        NV_C0_BC3__VS_FREQ_I = 1572,
        NV_C0_BC3_IM_LEVEL1_I = 1593,
        NV_C0_BC3_IM_LEVEL2_I = 1594,
        NV_C0_BC3_IM_LEVEL3_I = 1595,
        NV_C0_BC3_IM_LEVEL4_I = 1596,
        NV_C0_BC3_IM2_I_VALUE_I = 1580,
        NV_C0_BC3_IM2_Q_VALUE_I = 1581,
        NV_C0_BC3_IM2_TRANSCONDUCTOR_VALUE_I = 1584,
        NV_C0_BC3_LNA_1_FALL_I = 1586,
        NV_C0_BC3_LNA_1_OFFSET_I = 1576,
        NV_C0_BC3_LNA_1_RISE_I = 1585,
        NV_C0_BC3_LNA_2_FALL_I = 1588,
        NV_C0_BC3_LNA_2_OFFSET_I = 1577,
        NV_C0_BC3_LNA_2_OFFSET_VS_FREQ_I = 1573,
        NV_C0_BC3_LNA_2_RISE_I = 1587,
        NV_C0_BC3_LNA_3_FALL_I = 1590,
        NV_C0_BC3_LNA_3_OFFSET_I = 1578,
        NV_C0_BC3_LNA_3_OFFSET_VS_FREQ_I = 1574,
        NV_C0_BC3_LNA_3_RISE_I = 1589,
        NV_C0_BC3_LNA_4_FALL_I = 1592,
        NV_C0_BC3_LNA_4_OFFSET_I = 1579,
        NV_C0_BC3_LNA_4_OFFSET_VS_FREQ_I = 1575,
        NV_C0_BC3_LNA_4_RISE_I = 1591,
        NV_C0_BC3_TX_CAL_CHAN_I = 1570,
        NV_C0_BC3_RX_CAL_CHAN_I = 1571,
        NV_C0_BC3_VGA_GAIN_OFFSET_I = 1582,
        NV_C0_BC3_VGA_GAIN_OFFSET_VS_FREQ_I = 1583,
        NV_C0_BC4__VS_FREQ_I = 1493,
        NV_C0_BC4_IM_LEVEL1_I = 1514,
        NV_C0_BC4_IM_LEVEL2_I = 1515,
        NV_C0_BC4_IM_LEVEL3_I = 1516,
        NV_C0_BC4_IM_LEVEL4_I = 1517,
        NV_C0_BC4_IM2_I_VALUE_I = 1501,
        NV_C0_BC4_IM2_Q_VALUE_I = 1502,
        NV_C0_BC4_IM2_TRANSCONDUCTOR_VALUE_I = 1505,
        NV_C0_BC4_LNA_1_FALL_I = 1507,
        NV_C0_BC4_LNA_1_OFFSET_I = 1497,
        NV_C0_BC4_LNA_1_RISE_I = 1506,
        NV_C0_BC4_LNA_2_FALL_I = 1509,
        NV_C0_BC4_LNA_2_OFFSET_I = 1498,
        NV_C0_BC4_LNA_2_OFFSET_VS_FREQ_I = 1494,
        NV_C0_BC4_LNA_2_RISE_I = 1508,
        NV_C0_BC4_LNA_3_FALL_I = 1511,
        NV_C0_BC4_LNA_3_OFFSET_I = 1499,
        NV_C0_BC4_LNA_3_OFFSET_VS_FREQ_I = 1495,
        NV_C0_BC4_LNA_3_RISE_I = 1510,
        NV_C0_BC4_LNA_4_FALL_I = 1513,
        NV_C0_BC4_LNA_4_OFFSET_I = 1500,
        NV_C0_BC4_LNA_4_OFFSET_VS_FREQ_I = 1496,
        NV_C0_BC4_LNA_4_RISE_I = 1512,
        NV_C0_BC4_TX_CAL_CHAN_I = 1491,
        NV_C0_BC4_RX_CAL_CHAN_I = 1492,
        NV_C0_BC4_VGA_GAIN_OFFSET_I = 1503,
        NV_C0_BC4_VGA_GAIN_OFFSET_VS_FREQ_I = 1504,
        NV_C0_BC5_IM_LEVEL1_I = 1436,
        NV_C0_BC5_IM_LEVEL2_I = 1437,
        NV_C0_BC5_IM_LEVEL3_I = 1438,
        NV_C0_BC5_IM_LEVEL4_I = 1439,
        NV_C0_BC5_IM2_I_VALUE_I = 1423,
        NV_C0_BC5_IM2_Q_VALUE_I = 1424,
        NV_C0_BC5_IM2_TRANSCONDUCTOR_VALUE_I = 1427,
        NV_C0_BC5_LNA_1_FALL_I = 1429,
        NV_C0_BC5_LNA_1_OFFSET_I = 1419,
        NV_C0_BC5_LNA_1_OFFSET_VS_FREQ_I = 1415,
        NV_C0_BC5_LNA_1_RISE_I = 1428,
        NV_C0_BC5_LNA_2_FALL_I = 1431,
        NV_C0_BC5_LNA_2_OFFSET_I = 1420,
        NV_C0_BC5_LNA_2_OFFSET_VS_FREQ_I = 1416,
        NV_C0_BC5_LNA_2_RISE_I = 1430,
        NV_C0_BC5_LNA_3_FALL_I = 1433,
        NV_C0_BC5_LNA_3_OFFSET_I = 1421,
        NV_C0_BC5_LNA_3_OFFSET_VS_FREQ_I = 1417,
        NV_C0_BC5_LNA_3_RISE_I = 1432,
        NV_C0_BC5_LNA_4_FALL_I = 1435,
        NV_C0_BC5_LNA_4_OFFSET_I = 1422,
        NV_C0_BC5_LNA_4_OFFSET_VS_FREQ_I = 1418,
        NV_C0_BC5_LNA_4_RISE_I = 1434,
        NV_C0_BC5_TX_CAL_CHAN_I = 1413,
        NV_C0_BC5_RX_CAL_CHAN_I = 1414,
        NV_C0_BC5_VGA_GAIN_OFFSET_I = 1425,
        NV_C0_BC5_VGA_GAIN_OFFSET_VS_FREQ_I = 1426,
        NV_C0_BC6_DIGITAL_MIS_COMP_A_OFFSET_I = 1266,
        NV_C0_BC6_DIGITAL_MIS_COMP_B_OFFSET_I = 1268,
        NV_C0_BC6_IM_LEVEL1_I = 1230,
        NV_C0_BC6_IM_LEVEL2_I = 1231,
        NV_C0_BC6_IM_LEVEL3_I = 1232,
        NV_C0_BC6_IM_LEVEL4_I = 1233,
        NV_C0_BC6_IM2_I_VALUE_I = 1251,
        NV_C0_BC6_IM2_Q_VALUE_I = 1253,
        NV_C0_BC6_IM2_TRANSCONDUCTOR_VALUE_I = 1270,
        NV_C0_BC6_LNA_1_FALL_I = 1364,
        NV_C0_BC6_LNA_1_OFFSET_I = 1360,
        NV_C0_BC6_LNA_1_OFFSET_VS_FREQ_I = 1234,
        NV_C0_BC6_LNA_1_RISE_I = 1363,
        NV_C0_BC6_LNA_2_FALL_I = 1366,
        NV_C0_BC6_LNA_2_OFFSET_I = 1361,
        NV_C0_BC6_LNA_2_OFFSET_VS_FREQ_I = 1359,
        NV_C0_BC6_LNA_2_RISE_I = 1365,
        NV_C0_BC6_LNA_3_FALL_I = 1368,
        NV_C0_BC6_LNA_3_OFFSET_I = 1362,
        NV_C0_BC6_LNA_3_OFFSET_VS_FREQ_I = 1245,
        NV_C0_BC6_LNA_3_RISE_I = 1367,
        NV_C0_BC6_LNA_4_FALL_I = 1370,
        NV_C0_BC6_LNA_4_OFFSET_I = 1249,
        NV_C0_BC6_LNA_4_OFFSET_VS_FREQ_I = 1262,
        NV_C0_BC6_LNA_4_RISE_I = 1369,
        NV_C0_BC6_LNA_RANGE_OFFSET_I = 1225,
        NV_C0_BC6_P1_RISE_FALL_OFFSET_I = 1264,
        NV_C0_BC6_TX_CAL_CHAN_I = 1306,
        NV_C0_BC6_RX_CAL_CHAN_I = 1211,
        NV_C0_BC6_VGA_GAIN_OFFSET_I = 1255,
        NV_C0_BC6_VGA_GAIN_OFFSET_VS_FREQ_I = 1257,
        NV_C0_BC6_VGA_GAIN_OFFSET_VS_TEMP_I = 1259,
        NV_C1_BC0_IM_LEVEL1_I = 1787,
        NV_C1_BC0_IM_LEVEL2_I = 1788,
        NV_C1_BC0_IM_LEVEL3_I = 1789,
        NV_C1_BC0_IM_LEVEL4_I = 1790,
        NV_C1_BC0_IM2_I_VALUE_I = 1774,
        NV_C1_BC0_IM2_Q_VALUE_I = 1775,
        NV_C1_BC0_IM2_TRANSCONDUCTOR_VALUE_I = 1778,
        NV_C1_BC0_LNA_1_FALL_I = 1780,
        NV_C1_BC0_LNA_1_OFFSET_I = 1770,
        NV_C1_BC0_LNA_1_OFFSET_VS_FREQ_I = 1766,
        NV_C1_BC0_LNA_1_RISE_I = 1779,
        NV_C1_BC0_LNA_2_FALL_I = 1782,
        NV_C1_BC0_LNA_2_OFFSET_I = 1771,
        NV_C1_BC0_LNA_2_OFFSET_VS_FREQ_I = 1767,
        NV_C1_BC0_LNA_2_RISE_I = 1781,
        NV_C1_BC0_LNA_3_FALL_I = 1784,
        NV_C1_BC0_LNA_3_OFFSET_I = 1772,
        NV_C1_BC0_LNA_3_OFFSET_VS_FREQ_I = 1768,
        NV_C1_BC0_LNA_3_RISE_I = 1783,
        NV_C1_BC0_LNA_4_FALL_I = 1786,
        NV_C1_BC0_LNA_4_OFFSET_I = 1773,
        NV_C1_BC0_LNA_4_OFFSET_VS_FREQ_I = 1769,
        NV_C1_BC0_LNA_4_RISE_I = 1785,
        NV_C1_BC0_TX_CAL_CHAN_I = 1764,
        NV_C1_BC0_RX_CAL_CHAN_I = 1765,
        NV_C1_BC0_VGA_GAIN_OFFSET_I = 1776,
        NV_C1_BC0_VGA_GAIN_OFFSET_VS_FREQ_I = 1777,
        NV_C1_BC1_IM_LEVEL1_I = 1709,
        NV_C1_BC1_IM_LEVEL2_I = 1710,
        NV_C1_BC1_IM_LEVEL3_I = 1711,
        NV_C1_BC1_IM_LEVEL4_I = 1712,
        NV_C1_BC1_IM2_I_VALUE_I = 1696,
        NV_C1_BC1_IM2_Q_VALUE_I = 1697,
        NV_C1_BC1_IM2_TRANSCONDUCTOR_VALUE_I = 1700,
        NV_C1_BC1_LNA_1_FALL_I = 1702,
        NV_C1_BC1_LNA_1_OFFSET_I = 1692,
        NV_C1_BC1_LNA_1_OFFSET_VS_FREQ_I = 1687,
        NV_C1_BC1_LNA_1_RISE_I = 1701,
        NV_C1_BC1_LNA_2_FALL_I = 1704,
        NV_C1_BC1_LNA_2_OFFSET_I = 1693,
        NV_C1_BC1_LNA_2_OFFSET_VS_FREQ_I = 1689,
        NV_C1_BC1_LNA_2_RISE_I = 1703,
        NV_C1_BC1_LNA_3_FALL_I = 1706,
        NV_C1_BC1_LNA_3_OFFSET_I = 1694,
        NV_C1_BC1_LNA_3_OFFSET_VS_FREQ_I = 1690,
        NV_C1_BC1_LNA_3_RISE_I = 1705,
        NV_C1_BC1_LNA_4_FALL_I = 1708,
        NV_C1_BC1_LNA_4_OFFSET_I = 1695,
        NV_C1_BC1_LNA_4_OFFSET_VS_FREQ_I = 1691,
        NV_C1_BC1_LNA_4_RISE_I = 1707,
        NV_C1_BC1_TX_CAL_CHAN_I = 1685,
        NV_C1_BC1_RX_CAL_CHAN_I = 1686,
        NV_C1_BC1_VGA_GAIN_OFFSET_I = 1698,
        NV_C1_BC1_VGA_GAIN_OFFSET_VS_FREQ_I = 1699,
        NV_C1_BC3_IM_LEVEL1_I = 1620,
        NV_C1_BC3_IM_LEVEL2_I = 1621,
        NV_C1_BC3_IM_LEVEL3_I = 1622,
        NV_C1_BC3_IM_LEVEL4_I = 1623,
        NV_C1_BC3_IM2_I_VALUE_I = 1607,
        NV_C1_BC3_IM2_Q_VALUE_I = 1608,
        NV_C1_BC3_IM2_TRANSCONDUCTOR_VALUE_I = 1611,
        NV_C1_BC3_LNA_1_FALL_I = 1613,
        NV_C1_BC3_LNA_1_OFFSET_I = 1603,
        NV_C1_BC3_LNA_1_OFFSET_VS_FREQ_I = 1599,
        NV_C1_BC3_LNA_1_RISE_I = 1612,
        NV_C1_BC3_LNA_2_FALL_I = 1615,
        NV_C1_BC3_LNA_2_OFFSET_I = 1604,
        NV_C1_BC3_LNA_2_OFFSET_VS_FREQ_I = 1600,
        NV_C1_BC3_LNA_2_RISE_I = 1614,
        NV_C1_BC3_LNA_3_FALL_I = 1617,
        NV_C1_BC3_LNA_3_OFFSET_I = 1605,
        NV_C1_BC3_LNA_3_OFFSET_VS_FREQ_I = 1601,
        NV_C1_BC3_LNA_3_RISE_I = 1616,
        NV_C1_BC3_LNA_4_FALL_I = 1619,
        NV_C1_BC3_LNA_4_OFFSET_I = 1606,
        NV_C1_BC3_LNA_4_OFFSET_VS_FREQ_I = 1602,
        NV_C1_BC3_LNA_4_RISE_I = 1618,
        NV_C1_BC3_TX_CAL_CHAN_I = 1597,
        NV_C1_BC3_RX_CAL_CHAN_I = 1598,
        NV_C1_BC3_VGA_GAIN_OFFSET_I = 1609,
        NV_C1_BC3_VGA_GAIN_OFFSET_VS_FREQ_I = 1610,
        NV_C1_BC4_IM_LEVEL1_I = 1541,
        NV_C1_BC4_IM_LEVEL2_I = 1542,
        NV_C1_BC4_IM_LEVEL3_I = 1543,
        NV_C1_BC4_IM_LEVEL4_I = 1544,
        NV_C1_BC4_IM2_I_VALUE_I = 1528,
        NV_C1_BC4_IM2_Q_VALUE_I = 1529,
        NV_C1_BC4_IM2_TRANSCONDUCTOR_VALUE_I = 1532,
        NV_C1_BC4_LNA_1_FALL_I = 1534,
        NV_C1_BC4_LNA_1_OFFSET_I = 1524,
        NV_C1_BC4_LNA_1_OFFSET_VS_FREQ_I = 1520,
        NV_C1_BC4_LNA_1_RISE_I = 1533,
        NV_C1_BC4_LNA_2_FALL_I = 1536,
        NV_C1_BC4_LNA_2_OFFSET_I = 1525,
        NV_C1_BC4_LNA_2_OFFSET_VS_FREQ_I = 1521,
        NV_C1_BC4_LNA_2_RISE_I = 1535,
        NV_C1_BC4_LNA_3_FALL_I = 1538,
        NV_C1_BC4_LNA_3_OFFSET_I = 1526,
        NV_C1_BC4_LNA_3_OFFSET_VS_FREQ_I = 1522,
        NV_C1_BC4_LNA_3_RISE_I = 1537,
        NV_C1_BC4_LNA_4_FALL_I = 1540,
        NV_C1_BC4_LNA_4_OFFSET_I = 1527,
        NV_C1_BC4_LNA_4_OFFSET_VS_FREQ_I = 1523,
        NV_C1_BC4_LNA_4_RISE_I = 1539,
        NV_C1_BC4_TX_CAL_CHAN_I = 1518,
        NV_C1_BC4_RX_CAL_CHAN_I = 1519,
        NV_C1_BC4_VGA_GAIN_OFFSET_I = 1530,
        NV_C1_BC4_VGA_GAIN_OFFSET_VS_FREQ_I = 1531,
        NV_C1_BC5_IM_LEVEL1_I = 1463,
        NV_C1_BC5_IM_LEVEL2_I = 1464,
        NV_C1_BC5_IM_LEVEL3_I = 1465,
        NV_C1_BC5_IM_LEVEL4_I = 1466,
        NV_C1_BC5_IM2_I_VALUE_I = 1450,
        NV_C1_BC5_IM2_Q_VALUE_I = 1451,
        NV_C1_BC5_IM2_TRANSCONDUCTOR_VALUE_I = 1454,
        NV_C1_BC5_LNA_1_FALL_I = 1456,
        NV_C1_BC5_LNA_1_OFFSET_I = 1446,
        NV_C1_BC5_LNA_1_OFFSET_VS_FREQ_I = 1442,
        NV_C1_BC5_LNA_1_RISE_I = 1455,
        NV_C1_BC5_LNA_2_FALL_I = 1458,
        NV_C1_BC5_LNA_2_OFFSET_I = 1447,
        NV_C1_BC5_LNA_2_OFFSET_VS_FREQ_I = 1443,
        NV_C1_BC5_LNA_2_RISE_I = 1457,
        NV_C1_BC5_LNA_3_FALL_I = 1460,
        NV_C1_BC5_LNA_3_OFFSET_I = 1448,
        NV_C1_BC5_LNA_3_OFFSET_VS_FREQ_I = 1444,
        NV_C1_BC5_LNA_3_RISE_I = 1459,
        NV_C1_BC5_LNA_4_FALL_I = 1462,
        NV_C1_BC5_LNA_4_OFFSET_I = 1449,
        NV_C1_BC5_LNA_4_OFFSET_VS_FREQ_I = 1445,
        NV_C1_BC5_LNA_4_RISE_I = 1461,
        NV_C1_BC5_TX_CAL_CHAN_I = 1440,
        NV_C1_BC5_RX_CAL_CHAN_I = 1441,
        NV_C1_BC5_VGA_GAIN_OFFSET_I = 1452,
        NV_C1_BC5_VGA_GAIN_OFFSET_VS_FREQ_I = 1453,
        NV_C1_BC6_DIGITAL_MIS_COMP_A_OFFSET_I = 1267,
        NV_C1_BC6_DIGITAL_MIS_COMP_B_OFFSET_I = 1269,
        NV_C1_BC6_IM_LEVEL1_I = 1385,
        NV_C1_BC6_IM_LEVEL2_I = 1386,
        NV_C1_BC6_IM_LEVEL3_I = 1387,
        NV_C1_BC6_IM_LEVEL4_I = 1388,
        NV_C1_BC6_IM2_I_VALUE_I = 1252,
        NV_C1_BC6_IM2_Q_VALUE_I = 1254,
        NV_C1_BC6_IM2_TRANSCONDUCTOR_VALUE_I = 1271,
        NV_C1_BC6_LNA_1_FALL_I = 1378,
        NV_C1_BC6_LNA_1_OFFSET_I = 1374,
        NV_C1_BC6_LNA_1_OFFSET_VS_FREQ_I = 1235,
        NV_C1_BC6_LNA_1_RISE_I = 1377,
        NV_C1_BC6_LNA_2_FALL_I = 1380,
        NV_C1_BC6_LNA_2_OFFSET_I = 1375,
        NV_C1_BC6_LNA_2_OFFSET_VS_FREQ_I = 1373,
        NV_C1_BC6_LNA_2_RISE_I = 1379,
        NV_C1_BC6_LNA_3_FALL_I = 1382,
        NV_C1_BC6_LNA_3_OFFSET_I = 1376,
        NV_C1_BC6_LNA_3_OFFSET_VS_FREQ_I = 1246,
        NV_C1_BC6_LNA_3_RISE_I = 1381,
        NV_C1_BC6_LNA_4_FALL_I = 1384,
        NV_C1_BC6_LNA_4_OFFSET_I = 1250,
        NV_C1_BC6_LNA_4_OFFSET_VS_FREQ_I = 1263,
        NV_C1_BC6_LNA_4_RISE_I = 1383,
        NV_C1_BC6_LNA_RANGE_OFFSET_I = 1226,
        NV_C1_BC6_P1_RISE_FALL_OFFSET_I = 1265,
        NV_C1_BC6_TX_CAL_CHAN_I = 1371,
        NV_C1_BC6_RX_CAL_CHAN_I = 1372,
        NV_C1_BC6_VGA_GAIN_OFFSET_I = 1256,
        NV_C1_BC6_VGA_GAIN_OFFSET_VS_FREQ_I = 1258,
        NV_C1_BC6_VGA_GAIN_OFFSET_VS_TEMP_I = 1260,

        NV_RFR_BB_FILTER_I = 1791,
        NV_RFR_IQ_LINE_RESISTOR_I = 1792,
        NV_PA_R_MAP_I = 1875,
        NV_RF_BC_CONFIG_I = 1877,
        NV_RF_HW_CONFIG_I = 1878,
        NV_BC0_HDR_IM_FALL_I = 1879,
        NV_BC0_HDR_IM_RISE_I = 1880,
        NV_BC0_HDR_IM_LEVEL_I = 1890,

        NV_CDMA_P1_RISE_FALL_OFF_I = 1891,
        NV_PCS_P1_RISE_FALL_OFF_I = 1892,

        NV_MEID_I = 1943,

        NV_FACTORY_DATA_1_I = 2497,  // User Data #1

        NV_FACTORY_DATA_2_I = 2498,  // User Data #2

        NV_FACTORY_DATA_3_I = 2499,  // User Data #3

        NV_FACTORY_DATA_4_I = 2500,  // User Data #4

        NV_DS_MIP_RM_NAI = 2825, //Tethered NAI

        NV_MF_700_AGC_VS_FREQ_I = 3370,

        NV_MF_HW_CONFIG = 3372,

        NV_MF_BAND_CONFIG = 3373,

        NV_WCDMA_RX_DIVERSITY_CTRL = 3851,

        NV_MF_CHAN_SUPPORT = 4104,

        NV_MF_RSSI_CAL_VS_FREQ_0 = 4106,

        NV_MF_RSSI_CAL_VS_FREQ_1 = 4107,

        NV_MF_RSSI_CAL_VS_FREQ_2 = 4108,

        NV_MF_RSSI_CAL_VS_FREQ_3 = 4109,

        NV_SEC_CSPRNG_INIT_SEED_I = 4184,

        NV_PM_CONFIG = 4257,

        //gdoud.  Added for UNDP 12_20_07

        NV_HS_USB_CURRENT_COMPOSITION_I = 4526,

        NV_WLAN_MAC_ADDRESS_I = 4678,

        NV_MF_RSSI_CAL_VS_FREQ_4 = 4720,

        NV_MF_RSSI_CAL_VS_FREQ_5 = 4721,

        NV_HW_ENTROPY_I = 5045,

        NV_CGPS_NMEA_CONFIG_INFO_I = 5047,

        RFNV_RF_BC_CONFIG_C2_I = 22131,
        RFNV_RF_BC_CONFIG_C3_I = 23387,
        RFNV_RF_BC_CONFIG_C4_I = 28775,
        RFNV_RF_BC_CONFIG_C5_I = 28776,

        NV_MAX_I,                    /* Size of this enum, MUST be the last item */
        /* (except for padding)                     */
        /*-------------------------------------------------------------------------*/

        NV_ITEMS_ENUM_PAD = 0x7FFF   /* Pad to 16 bits on ARM                    */

    };

    public enum nv_stat_enum_type
    {
        NV_DONE_S,          //!<' Request completed okay 
        NV_BUSY_S,          //!<' Request is queued
        NV_BADCMD_S,        //!<' Unrecognizable command field
        NV_FULL_S,          //!<' The NVM is full
        NV_FAIL_S,          //!<' Command failed, reason other than NVM was full 
        NV_NOTACTIVE_S,     //!<' Variable was not active
        NV_BADPARM_S,       //!<' Bad parameter in command block
        NV_READONLY_S,      //!<' Parameter is write-protected and thus read only
        NV_BADTG_S,         //!<' Item not valid for Target 
        NV_NOMEM_S,         //!<' free memory exhausted
        NV_NOTALLOC_S,      //!<' address is not a valid allocation
        NV_STAT_ENUM_PAD = 0x7FFF     //!<' Pad to 16 bits on ARM
    };

    /// <summary>
    /// Enumeration of QMSL library modes
    /// </summary>
    public enum LibraryModeEnum
    {
        QPhoneMS = 0,
        QPST = 1
    };

    public enum mf_hw_config
    {
        Narrow_Band_ICOff_MultiFreq = 0,
        Narrow_Band_ICOff = 2,
        Narrow_Band_ICOn_MultiFreq = 8,
        Narrow_Band_ICOn = 10,
        Narrow_Band_ICOn_Adaptive_MultiFreq = 12,
        Narrow_Band_ICOn_Adaptive = 14,
        Wide_Band_ICOff_MultiFreq = 16,
        Wide_Band_ICOff = 18,
        Wide_Band_ICOn_MultiFreq = 24,
        Wide_Band_ICOn = 26,
        Wide_Band_ICOn_Adaptive_MultiFreq = 28,
        Wide_Band_ICOn_Adaptive = 30,
        L_Band_ICOff_MultiFreq = 32,
        L_Band_ICOff = 34,
        L_Band_ICOn_MultiFreq = 40,
        L_Band_ICOn = 42,
        L_Band_ICOn_Adaptive_MultiFreq = 44,
        L_Band_ICOn_Adaptive = 46,
    };

    public class QMSL_Event_Element_Struct
    {
        public byte time_length;   //!< # of bytes used to store type, 8 = full system time (FULL_SYSTEM_TIMESTAMP), 2=Truncated time (TRUNCATED_TIMESTAMP)
        public byte[] time;// = new time[8];      //!< 8 or 2 bytes of system time, format depends upon time_length field
        public ushort event_id;   //!< 12-bit unique ID of event
        public byte payload_len;   //!< # of bytes stored in payload_len
        public byte[] payload_data;//= new byte[QMSL_EVENT_PAYLOAD_DATA_MAX];   //!< payload data, payload_len field determines # of valid bytes

        public QMSL_Event_Element_Struct()
        {

        }
    };

    public enum cmd_code
    {
        _DIAG_VERNO_F = 0,   //   !<'   Version   Number   Request   Response               
        _DIAG_ESN_F = 1,   //   !<'   Mobile   Station   ESN   Request   Response            
        _DIAG_MEMORY_PEEK_BYTE_F = 2,   //   !<'   Memory   peek   request   response   (8-bit)            
        _DIAG_MEMORY_PEEK_WORD_F = 3,   //   !<'   Memory   peek   request   response   (16-bit)            
        _DIAG_MEMORY_PEEK_DWORD_F = 4,   //   !<'   Memory   peek   request   response   (32-bit)            
        _DIAG_MEMORY_POKE_BYTE_F = 5,   //   !<'   Memory   poke   request   response   (8-bit)            
        _DIAG_MEMORY_POKE_WORD_F = 6,   //   !<'   Memory   poke   request   response   (16-bit)            
        _DIAG_MEMORY_POKE_DWORD_F = 7,   //   !<'   Memory   poke   request   response   (32-bit)            
        _DIAG_STATUS_REQUEST_F = 12,   //   !<'Status   Request   Response                     
        _DIAG_STATUS_F = 14,   //   !<'   Phone   status                     
        _DIAG_LOG_F = 16,   //   !<'   Log   packet   Request   Response               
        _DIAG_BAD_CMD_F = 19,   //   !<'   Invalid   Command   Response                  
        _DIAG_BAD_PARM_F = 20,   //   !<'   Invalid   parmaeter   Response                  
        _DIAG_BAD_LEN_F = 21,   //   !<'   Invalid   packet   length   Response               
        _DIAG_BAD_MODE_F = 24,    //   !<'   Packet   not   allowed   in   this   mode
        /* 22-23 Reserved */
        /* Packet not allowed in this mode */
        /*( online vs offline ) */
        DIAG_BAD_MODE_F = 24,
        _DIAG_MSG_F = 31,   //   !<'   Request   for   msg   report               
        _DIAG_HS_KEY_F = 32,   //   !<'   Handset   Emulation   --   keypress               
        _DIAG_NV_READ_F = 38,   //   !<'   Read   NV   item                  
        _DIAG_NV_WRITE_F = 39,   //   !<'   Write   NV   item                  
        _DIAG_CONTROL_F = 41,   //   !<'   Mode   change   request                  
        _DIAG_ERR_READ_F = 42,   //   !<'   Read   error   list                  
        _DIAG_ERR_CLEAR_F = 43,   //   !<'   Clear   error   list                  
        _DIAG_GET_DIPSW_F = 47,   //   !<'   Retreive   dipswitch                     
        _DIAG_SET_DIPSW_F = 48,   //   !<'   Set   dipswitch                     
        _DIAG_VOC_PCM_LB_F = 49,   //   !<'   Start   Stop   Vocoder   PCM   loopback            
        _DIAG_VOC_PKT_LB_F = 50,   //   !<'   Start   Stop   Vocoder   PKT   loopback            
        _DIAG_DLOAD_F = 58,   //   !<'   Switch   to   download   mode               
        _DIAG_SPC_F = 65,   //   !<'   Send   the   Service   Prog.   Code   to   allow   SP   
        _DIAG_SERIAL_MODE_CHANGE = 68, //!<'   Switch   mode   from   diagnostic   to   data            
        _DIAG_EXT_LOGMASK_F = 93,   //   !<'   Extended   logmask   for   >   32   bits.         
        _DIAG_EVENT_REPORT_F = 96,   //   !<'   Static   Event   reporting.                  
        _DIAG_SUBSYS_CMD_F = 75,   //   !<'   Subssytem   dispatcher   (extended   diag   cmd)            
        _DIAG_NV_WRITE_ONLINE_F = 76,   //   !<'   Write   to   NV   location   without   going   Offline      
        _DIAG_GPS_CMD_F = 108,
        _DIAG_LOG_CONFIG_F = 115,   //   !<'   Logging   configuration   packet                  
        _DIAG_EXT_MSG_F = 121,   //   !<'   Extended   msg   report                  
        _DIAG_PROTOCOL_LOOPBACK_F = 123,   //   !<'   Diagnostics   protocol   loopback.                  
        _DIAG_EXT_BUILD_ID_F = 124,   //   !<'   Extended   build   ID                  
        _DIAG_EXT_MSG_CONFIG_F = 125,   //   !<'   Request   for   extended   msg   report            
        _DIAG_SECURITY_FREEZE_F = 0xff,   //   0xff   !<'   Request   for   Sirius   security   freeze   (not   defined   yet)
        _DIAG_MAX_F = 126,   //   !<'   Number   of   packets   defined.               
        _DIAG_SUBSYS_CMD_VER_2_F = 128,   //                              
        _DIAG_EVENT_MASK_GET_F = 129,   //   !<'   Get   event   mask                  
        _DIAG_EVENT_MASK_SET_F = 130      //   !<'   Set   event   mask                  
    };

    public enum mode_enum_type
    {
        MODE_OFFLINE_A_F = 0,   //!<' Go to offline analog
        MODE_OFFLINE_D_F = 1,   //!<' Go to offline digital 
        MODE_RESET_F = 2,      //!<' Reset. Only exit from offline 
        MODE_FTM_F = 3,         //!<' FTM mode
        MODE_ONLINE_F = 4,      //!<' Go to Online 
        MODE_LPM_F = 5,         //!<' Low Power Mode (if supported)
        MODE_POWER_OFF_F = 6,   //!<' Power off (if supported)
        MODE_MAX_F = 7         //!<' Last (and invalid) mode enum value
    };

    public enum FTM_Mode_Id_Enum
    {
        FTM_MODE_ID_CDMA_1X = 0,      //!<' RF CDMA 1X mode - RX0
        FTM_MODE_ID_WCDMA = 1,      //!<' RF WCDMA mode
        FTM_MODE_ID_GSM = 2,      //!<' RF GSM Mode
        FTM_MODE_ID_CDMA_1X_RX1 = 3,      //!<' RF CDMA 1X mode - RX1
        FTM_MODE_ID_BLUETOOTH = 4,      //!<' Bluetooth
        FTM_MODE_ID_CDMA_1X_CALL = 7,      //!<' CALL CDMA 1X mode 
        FTM_MODE_ID_HDR_C = 8,      //!<' HDC non signaling
        FTM_MODE_ID_LOGGING = 9,      //!<' FTM Logging
        FTM_MODE_ID_AGPS = 10,      //!<' Async GPS
        FTM_MODE_ID_PMIC = 11,      //!<' PMIC FTM Command
        FTM_MODE_GSM_BER = 13,      //!<' GSM BER
        FTM_MODE_ID_AUDIO = 14,      //!<' Audio FTM
        FTM_MODE_ID_CAMERA = 15,      //!<' Camera
        FTM_MODE_WCDMA_BER = 16,      //!<' WCDMA BER
        FTM_MODE_ID_GSM_EXTENDED_C = 17,   //!<' GSM Extended commands
        FTM_MODE_CDMA_API_V2 = 18,      //!<' CDMA RF Cal API v2
        FTM_MODE_ID_MF_C = 19,      //!<' MediaFLO
        FTM_MODE_RF_COMMON = 20,      //!<' RF Common
        FTM_MODE_WCDMA_RX1 = 21,      //!<' WCDMA diversity RX (RX1)
        FTM_MODE_WLAN = 22,      //!<' WLAN FTM
        FTM_MODE_QFUSE = 24,      //!<' QFUSE FTM
        FTM_MODE_ID_MF_NS = 26,
        FTM_MODE_ID_LTE = 29,       //!<' LTE FTM Calibration
        FTM_MODE_ID_CDMA_1X_C2 = 32,       //!<' CDMA SV Path mode - Chain 2
        FTM_MODE_IRAT = 33,       //!<' FTM IRAT
        FTM_MODE_LTE_RX1 = 35,       //!<' LTE FTM Calibration Diversity
        FTM_MODE_ID_1X_C3_C = 40,   //!<' FTM_1X_C3_C
        FTM_MODE_ID_TDSCDMA = 42,  //!<' FTM_MODE_ID_TDSCDMA
        FTM_MODE_ID_TDSCDMA_RX1 = 43,   //!<' FTM_MODE_ID_TDSCDMA_RX1
        FTM_MODE_ID_1X_C4_C = 45,   //!<' FTM_1X_C4_C
        FTM_MODE_ID_LTE_C3 = 47,    //!<' LTE Mode ID for SCell Primary
        FTM_MODE_ID_LTE_C4 = 48,    //!<' LTE Mode ID for SCell Secondary
        FTM_MODE_ID_GSM_C2 = 49,    //!<' FTM_GSM_C2_C (chain 2)
        FTM_MODE_WCDMA_RX3_C = 56,    //!<' WCDMA Chain 3
        FTM_MODE_WCDMA_RX4_C = 57,    //!<' WCDMA Chain 4 
        FTM_MODE_ID_LTE_C5 = 65,     //!<' LTE Mode ID for SCell2 Primary
        FTM_MODE_ID_LTE_C6 = 66,     //!<' LTE Mode ID for SCell2 Diversity
        FTM_MODE_WCDMA_RX5_C = 68,    //!<' WCDMA Chain 5
        FTM_MODE_WCDMA_RX6_C = 69,    //!<' WCDMA Chain 6
        FTM_MODE_WCDMA_RX7_C = 70,    //!<' WCDMA Chain 7
        FTM_MODE_WCDMA_RX8_C = 71,    //!<' WCDMA Chain 8
        FTM_TDSCDMA_C2_C = 99,      //!<' TDSCDMA C2
        FTM_TDSCDMA_C3_C = 100,     //!<' TDSCDMA C3
        FTM_MODE_ID_1X_C5_C = 118,   //!<' FTM_1X_C5_C

        FTM_MODE_ID_GSM_C4 = 101,    // !<' FTM_GSM_C4_C (chain 4)
        FTM_MODE_ID_PRODUCTION = 0x8000,   //!<' Production FTM
        FTM_MODE_ID_LTM = 0x8001   //!<' LTM
    };

    public enum FTM_SecondaryChainMode
    {
        FTM_Secondary_Rx_Disabled = 0,
        FTM_Secondary_Rx_Diversity = 1,
        FTM_Secondary_Rx_OFS = 2
    };

    public enum FTM_RF_Mode_Enum
    {
        PHONE_MODE_FM = 1,             //!<' FM
        PHONE_MODE_SLEEP = 2,              //!<' Sleep Mode
        PHONE_MODE_GPS = 3,                //!<' GPS
        PHONE_MODE_GPS_SINAD = 4,          //!<' GPS SINAD
        PHONE_MODE_CDMA_800 = 5,           //!<' CDMA 800
        PHONE_MODE_CDMA_1900 = 6,          //!<' CDMA 1900
        PHONE_MODE_CDMA_1800 = 8,          //!<' CDMA 1800
        PHONE_MODE_J_CDMA = 14,            //!<' JCDMA
        PHONE_MODE_CDMA_450 = 17,          //!<' CDMA 450
        PHONE_MODE_CDMA_IMT = 19,          //!<' CDMA IMT
        PHONE_MODE_CDMA_1900_EXT = 26, //!<' Secndary CDMA 1900MHz Band, Band Class 14
        PHONE_MODE_CDMA_450_EXT = 27,      //!<' CDMA BC 11 (450 Extension)
        PHONE_MODE_CDMA_800_SEC = 33,      //!<' Secondary CDMA 800MHz Band, Band Class 10


        PHONE_MODE_WCDMA_IMT = 9,          //!<' WCDMA IMT, Band I
        PHONE_MODE_GSM_900 = 10,           //!<' GSM 900
        PHONE_MODE_GSM_1800 = 11,          //!<' GSM 1800
        PHONE_MODE_GSM_1900 = 12,          //!<' GSM 1900
        PHONE_MODE_BLUETOOTH = 13,     //!<' Bluetooth
        PHONE_MODE_WCDMA_1900A = 15,       //!<' WCDMA 1900 A, Band II Add
        PHONE_MODE_WCDMA_1900B = 16,       //!<' WCDMA 1900 B, Band II Gen
        PHONE_MODE_GSM_850 = 18,           //!<' GSM 850
        PHONE_MODE_WCDMA_800 = 22,     //!<' WCDMA 800, Band V Gen
        PHONE_MODE_WCDMA_800A = 23,        //!<' WCDMA 800, Band V Add
        PHONE_MODE_WCDMA_1800 = 25,        //!<' WCDMA 1800, Band III
        PHONE_MODE_WCDMA_BC4 = 28,     //!<' WCDMA BC4-used for both Band IV Gen and Band IV Add
        PHONE_MODE_WCDMA_BC8 = 29,     //!<' WCDMA BC8, Band VIII

        PHONE_MODE_MF_700 = 30,            //!<' MediaFLO
        PHONE_MODE_WCDMA_BC9 = 31,     //!<' WCDMA BC9 (1750MHz & 1845MHz), Band IX
        PHONE_MODE_CDMA_BC15 = 32,     //!<' CDMA Band Class 15
        PHONE_MODE_LTE_B1 = 34,            //!<' LTE Band Class 1
        PHONE_MODE_LTE_B7 = 35,            //!<' LTE Band Class 7
        PHONE_MODE_LTE_B4 = 42,            //!<' LTE Band Class 4
        PHONE_MODE_LTE_B11 = 41,           //!<' LTE Band Class 11
        PHONE_MODE_LTE_B13 = 36,       //!<' LTE Band Class 13
        PHONE_MODE_LTE_B17 = 37,       //!<' LTE Band Class 17
        PHONE_MODE_LTE_B38 = 38,       //!<' LTE Band Class 38
        PHONE_MODE_LTE_B40 = 39,       //!<' LTE Band Class 40
        PHONE_MODE_WCDMA_1500 = 40,        //!<' WCDMA BC11 (1500MHz) Band XI

        PHONE_MODE_LTE_B2 = 43,
        PHONE_MODE_LTE_B3 = 44,
        PHONE_MODE_LTE_B5 = 45,
        PHONE_MODE_LTE_B6 = 46,
        PHONE_MODE_LTE_B8 = 47,
        PHONE_MODE_LTE_B9 = 48,
        PHONE_MODE_LTE_B10 = 49,
        PHONE_MODE_LTE_B12 = 50,
        PHONE_MODE_LTE_B14 = 51,
        PHONE_MODE_LTE_B15 = 52,
        PHONE_MODE_LTE_B16 = 53,
        PHONE_MODE_LTE_B18 = 54,
        PHONE_MODE_LTE_B19 = 55,
        PHONE_MODE_LTE_B20 = 56,
        PHONE_MODE_LTE_B21 = 57,
        PHONE_MODE_LTE_B22 = 58,
        PHONE_MODE_LTE_B23 = 59,
        PHONE_MODE_LTE_B24 = 60,
        PHONE_MODE_LTE_B25 = 61,
        PHONE_MODE_LTE_B26 = 62,
        PHONE_MODE_LTE_B27 = 63,
        PHONE_MODE_LTE_B28 = 64,
        PHONE_MODE_LTE_B29 = 65,
        PHONE_MODE_LTE_B30 = 66,
        PHONE_MODE_LTE_B31 = 67,
        PHONE_MODE_LTE_B32 = 68,
        PHONE_MODE_LTE_B33 = 69,
        PHONE_MODE_LTE_B34 = 70,
        PHONE_MODE_LTE_B35 = 71,
        PHONE_MODE_LTE_B36 = 72,
        PHONE_MODE_LTE_B37 = 73,
        PHONE_MODE_LTE_B39 = 74,

        PHONE_MODE_WCDMA_BC19 = 75,     //!<' WCDMA BC19 (subset of 800MHz) Band XIX
        PHONE_MODE_LTE_B41 = 76,
        PHONE_MODE_LTE_B42 = 77,

        /*TDSCDMA reserves 90 - 99*/
        PHONE_MODE_TDSCDMA_B34 = 90,
        PHONE_MODE_TDSCDMA_B39 = 91,
        PHONE_MODE_TDSCDMA_B40 = 92,

        /*
           QMSL Developers: please modify:
              - QLib.h  ->  QLIB_FTM_SET_MODE() 
              - Diag_FTM.cpp  ->  Diag_FTM::FTM_SET_MODE()
              - QLIBFTMPhone.cpp when this list is changed.
        */
        PHONE_MODE_MAX = 255            //!<' Maximum possible mode ID
    };

    public enum CDMA_Bands
    {
        CDMA_BC0 = 5,
        CDMA_BC1 = 6,
        CDMA_BC3 = 14,
        CDMA_BC4 = 8,
        CDMA_BC6 = 19,
        CDMA_BC15 = 32
    };

    public enum WCDMA_Bands
    {
        WCDMA_Band_I = 9,
        WCDMA_Band_II = 16,
        WCDMA_Band_III = 25,
        WCDMA_Band_IV = 28,
        WCDMA_Band_V = 22,
        WCDMA_Band_VIII = 29,
        WCDMA_Band_IX = 31
    };

    public enum GSM_Bands
    {
        GSM_Band_Cell_850 = 18,
        GSM_Band_PCS_1900 = 12,
        GSM_Band_EGSM_900 = 10,
        GSM_Band_DCS_1800 = 11
    };

    public enum GSM_ModulationScheme
    {
        MCS1 = 0,
        MCS2 = 1,
        MCS3 = 2,
        MCS4 = 3,
        MCS5 = 4,
        MCS6 = 5,
        MCS7 = 6,
        MCS8 = 7,
        MCS9 = 8
    }

    public enum LogCodes
    {
        // Log code for CGPS Measurement Report
        CGPS_MEASUREMENT_REPORT_LOG = 0x1371,

        // Log code for CGPS RF Status
        CGPS_RF_STATUS_REPORT_LOG = 0x1372,

        // Log code for IQ and FFT data
        CGPS_IQ_DATA_LOG = 0x138A,

        // Log code for prescribed dwell status
        CGPS_PRESCRIBED_DWELL_STATUS_LOG = 0x1374,

        // Log code for GPS soft decisions, used during the GPS BER test
        GPS_DEMOD_SOFT_DECISIONS_LOG = 0x1253,

        AAGPS_TYPE3_MEASUREMENT_REPORT_LOG = 0x701f
    }

    public enum LTELogCodes
    {
        // Log code for LTE AGC log packet
        LTE_AGC_LOG = 0xB111,

        // Log code for LTE antenna correlation results log packet
        LTE_ANT_CORRELATION_RESULTS = 0xB120
    }

    //! Structure used to parse log packets
    public struct logRecordHeader
    {
        public ushort msgType;
        public ushort length;
        public ushort length2;
        public ushort log_code;
        public byte[] timestamp;
        public byte[] data;
    };

    public enum TestCallMode
    {
        PrimaryOnly = 0,
        SecondaryOnly = 1,
        PrimaryAndSecondary = 2
    };

    public enum SIMLockFeatureType
    {
        NW,
        NS,
        SP,
        CP,
        SM,
        NWU,
        NSU,
        SPU,
        CPU,
        SMU
    }

    public enum GSDI_DIAG_EventId
    {
        EVENT_GSDI_ACTIVATE_FEATURE_IND = 1037,
        EVENT_GSDI_DEACTIVATE_FEATURE_IND = 1038,
        EVENT_GSDI_GET_FEATURE_IND = 1039,
        EVENT_GSDI_SET_FEATURE_DATA = 1040,
        EVENT_GSDI_UNBLOCK_FEATURE_IND = 1041,
        EVENT_GSDI_GET_CONTROL_KEY = 1042
    };

    public enum Modulation_Data_Source
    {
        FTM_GSM_TX_DATA_SOURCE_PSDRND = 0,
        FTM_GSM_TX_DATA_SOURCE_TONE = 1,
        FTM_GSM_TX_DATA_SOURCE_BUFFER = 2,
        FTM_GSM_TX_DATA_SOURCE_TWOTONE = 3
    };

    public enum IsInfiniteDuration
    {
        Count_bursts = 0,
        Infinate = 1
    };

    public enum operatingMode_enum_type
    {
        SYS_OPRT_MODE_PWROFF = 0,   //!< ' Phone is powering off
        SYS_OPRT_MODE_FTM = 1,   //!< ' Phone is in factory test mode
        SYS_OPRT_MODE_OFFLINE = 2,   //!< ' Phone is offline
        SYS_OPRT_MODE_OFFLINE_AMPS = 3,   //!< ' Phone is offline analog
        SYS_OPRT_MODE_OFFLINE_CDMA = 4,   //!< ' Phone is offline cdma
        SYS_OPRT_MODE_ONLINE = 5,   //!< ' Phone is online
        SYS_OPRT_MODE_LPM = 6,   //!< ' Phone is in LPM - Low Power Mode
        SYS_OPRT_MODE_RESET = 7,   //!< ' Phone is resetting - i.e. power-cycling
        SYS_OPRT_MODE_NET_TEST_GW = 8,   //!< ' Phone is conducting network test for GSM/WCDMA.
        SYS_OPRT_MODE_OFFLINE_IF_NOT_FTM = 9, //!< ' offline request during powerup.
        SYS_OPRT_MODE_PSEUDO_ONLINE = 10, //!< ' Phone is pseudo online, tx disabled
        SYS_OPRT_MODE_APQ_DIAG_ALIVE = 12,      //!< 'Defined by QMSL, not by AMSS, indicate AMSS diag service is alive
        SYS_OPRT_MODE_APQ_DIAG_NO_RESPONSE = 13      //!< 'Defined by QMSL, not by AMSS, indicate AMSS diag service is dead (no diag response)
    };

    public enum BCValue_UInt64_BitMask
    {
        GSM_850 = 0x80000,
        EGSM_900 = 0x100,
        PGSM_900 = 0x200,
        DCS_1800 = 0x80,
        PCS_1900 = 0x200000
    };

    public enum GPS_Collect_Mode
    {
        GPS_Primary_Rx = 1,
        GLONASS_Primary_Rx = 3,
        GPS_High_Bandwidth_Rx = 4,
        BDS = 17,
        GAL = 18,
        UNKNOWN = 9999
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct GNSS_WB_FFT_Stats_v2
    {
        [FieldOffset(0)]
        public byte iVersion;           //!<' Version of the log

        [FieldOffset(1)]
        public UInt32 iGPSCNoDBHz;      //!<' Signal strength calculated in 0.1 dBHz as part of GPS WBIQ test

        [FieldOffset(5)]
        public Int32 iGPSFreq;           //!<' Frequency in Hz calculated as part of GPS WBIQ test

        [FieldOffset(9)]
        public UInt32 iGLOCNoDBHz;      //!<' Signal strength calculated in 0.1 dBHz as part of GLO WBIQ test

        [FieldOffset(13)]
        public Int32 iGLOFreq;           //!<' Frequency in Hz calculated as part of GLO WBIQ test

        [FieldOffset(17)]
        public UInt32 iBDSCNoDBHz;      //!<' Signal strength calculated in 0.1 dBHz as part of BDS WBIQ test

        [FieldOffset(21)]
        public Int32 iBDSFreq;           //!<' Frequency in Hz calculated as part of BDS WBIQ test

        [FieldOffset(25)]
        public UInt32 iGALCNoDBHz;      //!<' Signal strength calculated in 0.1 dBHz as part of GAL WBIQ test

        [FieldOffset(29)]
        public Int32 iGALFreq;           //!<' Frequency in Hz calculated as part of GAL WBIQ test

        [FieldOffset(33)]
        public byte iGNSSConfigMask;  //!<' Bit mask for GNSS Config: bit 0 - GPS, bit 1 - GLO, bit 4 - BDS, bit 5 - GAL

        [FieldOffset(34)]
        public Int32 iADCMeanI;          //!<' Mean estimate (DC) of the I component in ADC processor

        [FieldOffset(38)]
        public Int32 iADCMeanQ;          //!<' Mean estimate (DC) of the Q component in ADC processor

        [FieldOffset(42)]
        public Int32 iADCAmpI;           //!<' Amplitude estimate of the I component in ADC processor

        [FieldOffset(46)]
        public Int32 iADCAmpQ;           //!<' Amplitude estimate of the Q component in ADC processor
    }

    public enum QMSL_TimeOutType_Enum
    {
        // Timeouts for Diag_FTM area
        QMSL_Timeout_General,            //!< 'General communications time out, used for SendSync()  (4,000ms default)
        QMSL_Timeout_IsPhoneConnected,   //!< 'Timeout when connecting IsPhoneConnected() command (80ms default)
        QMSL_Timeout_Connect,            //!< 'Timeout for connecting to a phone the first time (200ms default)

        QMSL_Timeout_Nonsignaling,       //!< 'Non-signaling timeout (1,000ms default)

        QMSL_Timeout_GSDI,               //!< 'Timeout to be used for GSDI commands (6,000ms default)
        QMSL_Timeout_CNV,                //!< 'Timeout to be used for preparation of CNV (default 10,000ms)

        QMSL_Timeout_CDMA_FreqSweep, //!< 'Timeout to be used for CDMA Tx Rx Frequency Sweep (default 10,000ms)

        QMSL_Timeout_WriteData,          //!< 'Timeout to be used for writing data to a communications device,
        //!< ' does not include read back of response (default 900ms)
        //!< ' this cannot be set in QPST mode.

        QMSL_Timeout_ReadData,           //!< 'Timeout to be used for reading data from a communications device,
        //!< ' this timeout is only for the low level read operation and does not
        //!< ' consider the call context, such as whether a synchronous command is
        //!< ' currently being executed.  Default is 500ms

        QMSL_Timeout_GSDI_Event,     //!< 'Timeout to be used when waiting for a GSDI Diag event
        //!< ' Default is 3000ms

        QMSL_Timeout_CGPS_Event,     //!< 'Timeout to be used when waiting for events relatd to CGPS functions
        //!< ' Default is 10000ms

        /*
        Below this are configurable delays for the Diag_FTM area
        */

        /**
        Delay when switching from ONLINE-FTM mode.  This is needed
        for some targets because they do not process FTM commands
        immediately after going into FTM mode.  A recommended value
        is 200ms, but the default value is 0ms for backwards compatability.

        This is used in the function QLIB_DIAG_CONTROL_F()
        */
        QMSL_Timeout_Delay_ONLINE_FTM,

        /**
        Delay when switching to ONLINE mode.  This is needed
        because it often takes some time for the AMSS to change modes.
        Default is 0ms

        This is used in the function QLIB_DIAG_CONTROL_F()
        */
        QMSL_Timeout_Delay_ONLINE,

        /**
        Delay when switching to OFFLINE mode.  This is needed
        because it often takes some time for the AMSS to change modes, for example
        a power down registration must be done for some systems.
        Default is 3000ms

        This is used in the function QLIB_ChangeFTM_BootMode() and
        in QLIB_DIAG_CONTROL_F().
        */
        QMSL_Timeout_Delay_OFFLINE,

        /**
        This delay will be used when the mobile enters a GSM RF mode
        */
        QMSL_Timeout_Delay_GSM_RF_Mode,

        /**
        This delay will be used by QLIB_MFLO_GetPER_Phy() and QLIB_MFLO_GetPER_PhyMAC(),
        to set the delay between checking FLO status.  Default value is 100ms

        QLIB_MFLO_GetPER_Phy() uses this value to set the timeout when waiting for
        a status log.

        QLIB_MFLO_GetPER_PhyMAC() uses the value as the duration between the calls
        to poll the phone for status.

        This delay will be used by QLIB_MFLO_GetPER_Phy() and QLIB_MFLO_GetPER_PhyMAC(),
        to set the delay between checking FLO status.  Default value is 100ms.

        QLIB_MFLO_GetPER_Phy() uses this value as the duration between calls to get the
        stats when the stats are not updating.

        QLIB_MFLO_GetPER_PhyMAC() uses the value as the duration between the calls
        to get the next log packet from the queue when the queue is empty.
        */
        QMSL_Timeout_Delay_MediaFLO_StatusCheck,

        /**
        Timeout in ms for collecting async IQ log from ICI calibration

        This timeout is used by QLIB_FTM_GET_ICI_CAL_DATA()
        */
        QMSL_Timeout_ICI_IQ_Data,
        /**
        Timeout in ms for waiting for BT HCI response

        This timeout is used by QLIB_FTM_BT_HCI_USER_CMD_WithEventResponse
        */
        QMSL_Timeout_BT_HCI_Response,

        /**
        Timeout in ms for phone to complete runtime mode switching,
        valid only if the desired mode is Online, FTM , Offline, LPM, default value is 5000ms

        This timeout is used by QLIB_DIAG_CONTROL_F
        */
        QMSL_Timeout_Runtime_Mode_Switching,

        /**
        Timeout in ms for QMSL to return if the queue execution complete message is never received from embedded side

        Default is 10s (10000 ms)
        This timeout is used by QLIB_FTM_SEQ_EXECUTE_QUEUE
        */
        QMSL_Timeout_Embedded_Sequencer_Execution,

        // Note to QMSL developers, new delays and timeouts should be added here, before the
        // the SW Download timouts

        // Timeout for software download
        /**
        Timeout for the duration of the next softare download action.
        For example, a download that should take 7 minutes, the timeout can be set to 8 minutes.
        Default will be 10 minutes ( 10 minutes * 60seconds/minute * 1000milliseconds/secon = 600000ms
        */
        QMSL_Timeout_SoftwareDownloadActivity,

        QMSL_Timeout_ListSizeMax     //!< 'Not a timeout, just used to determine timeout list size
    };

    public class Mobile_CNo_Config
    {
        public ushort iCollect_Mode;
        public ushort iCapture_Size;
        public ushort iNumber_FFT_Integrations;
        public int GL0_FrequencyID;
        public int GL0_HW_Channel;
        public bool bCollectAllConstellations;
        public bool Exit_Sarf_On_Completion;
    };

    public class Mobile_CNo_Result
    {
        public bool bGPSValid;
        public bool bGL0Valid;
        public bool bBDSValid;
        public bool bGALValid;
        public double dMobile_reported_GPS_CNo_dB;
        public double dMobile_reported_GPS_Frequency_kHz;
        public double dMobile_reported_GLO_CNo_dB;
        public double dMobile_reported_GLO_Frequency_kHz;
        public double dMobile_reported_BDS_CNo_dB;
        public double dMobile_reported_BDS_Frequency_kHz;
        public double dMobile_reported_GAL_CNo_dB;
        public double dMobile_reported_GAL_Frequency_kHz;
        public double dMobile_reported_ADC_Mean_I_mv;
        public double dMobile_reported_ADC_Mean_q_mv;
        public double dMobile_reported_ADC_Amp_I_mv;
        public double dMobile_reported_ADC_Amp_q_mv;
    }

    public enum GPS_CFG_ENUM_MASK
    {
        GPS = 0x01,
        GLO = 0x02,
        BDS = 0x10,
        GAL = 0x20
    }

    public enum CGPS_GEN8_GNSS_ENGINE_Revisions
    {
        CGPS_GEN8_GNSS_ENGINE_REVISION_UNKNOWN = 0,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8 = 50,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8A = 51,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8A_SpecAn = 52,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8B = 53,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8B_BDS = 54,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8C = 55,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN8C_GAL = 56,
        CGPS_GEN8_GNSS_ENGINE_REVISION_GEN9 = 90,
        UNKNOWN_REVISION = 9999
    }

    public struct CGPS_Gen8_HwConfig_Struct_type
    {
        public byte u_RfMode;              //!< ' RF Mode:
        //!< '   0 - Ignore this field
        //!< '   1 - Narrowband GPS
        //!< '   2 - Wideband GPS
        //!< '   3 - Reserved
        //!< '   4 - GLONASS
        public byte u_RfLinearity;     //!< ' Linearity Mode:
        //!< '   0 - Ignore this field
        //!< '   1 - Low Linearity
        //!< '   2 - High Linearity
        //!< '   3 - Automatic
        public byte u_RfRxdOnTimeSec;  //!< ' Not Used
        public byte u_RfRxdOffTimeSec; //!< ' Not Used.
        public byte q_Reserved;            //!< ' Reserved, Must be 0.
    }

    public enum CGPS_GEN8_HwConfig_RF_MODE
    {
        CGPS_GEN8_HW_CONFIG_RF_MODE_IGNORE_FIELD,
        CGPS_GEN8_HW_CONFIG_RF_MODE_PRI_NB_RXD_ALWAYS_OFF,
        CGPS_GEN8_HW_CONFIG_RF_MODE_PRI_WB_RXD_ALWAYS_OFF,
        CGPS_GEN8_HW_CONFIG_RF_MODE_PRI_WB_RXD_ON,
        CGPS_GEN8_HW_CONFIG_RF_MODE_BP4_GLO_TEST,
        CGPS_GEN8_HW_CONFIG_RF_MODE_BP2_BDS_TEST
    }

    public enum CGPS_GEN8_HwConfig_RF_LINEARITY
    {
        CGPS_GEN8_HW_CONFIG_RF_LINEARITY_IGNORE_FIELD,
        CGPS_GEN8_HW_CONFIG_RF_LINEARITY_LOW = 1,
        CGPS_GEN8_HW_CONFIG_RF_LINEARITY_HIGH,
        CGPS_GEN8_HW_CONFIG_RF_LINEARITY_AUTO,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FTM_GET_RFFE_DEVICE_INFO_Request
    {
        public byte rf_mode;
        public byte rfm_device;
        public byte rffe_device_type;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FTM_RFFE_Info_Type
    {
        public ushort mfg_id;
        public ushort prd_id;
        public ushort prd_rev;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FTM_GET_RFFE_DEVICE_IDS_Response
    {
        public ushort status;
        public ushort num_device_instances;
        public FTM_RFFE_Info_Type[] device_info_ids;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FTM_GET_RFFE_DEVICE_INFO_Response
    {
        public byte cmd;
        public byte subsys;
        public ushort mode;
        public ushort ftm_cmd;
        public ushort status;
        public ushort mfg_id0;
        public ushort mfg_id1;
        public ushort mfg_id2;
        public ushort mfg_id3;
        public ushort mfg_id4;

        public ushort prd_id0;
        public ushort prd_id1;
        public ushort prd_id2;
        public ushort prd_id3;
        public ushort prd_id4;

        public ushort rev_id0;
        public ushort rev_id1;
        public ushort rev_id2;
        public ushort rev_id3;
        public ushort rev_id4;
    };

    /*===========================================================================*/
    /**
    enum for WCDMA non-signaling RMC type
    */
    /*===========================================================================*/
    public enum FTM_WCDMA_BER_RMC_Type_Enum
    {
        FTM_WCDMA_BER_RMC_Type12_2kpbs = 0,	//!<' RMC 12.2 kbps channel,
        FTM_WCDMA_BER_RMC_Type64kbps = 1,	//!<' RMC 64 kbps channel,
        FTM_WCDMA_BER_RMC_Type384kpbs = 2,	//!<' RMC 384 kbps channel, (Not currently supported)
        FTM_WCDMA_BER_RMC_Type12_2kpbs_Symmetric = 3,	//!<' RMC 12.2 kbps channel, block size in the DL and UL is the same
        FTM_WCDMA_BER_RMC_Type64kbps_Symmetric = 4,	//!<' RMC 64 kbps channel, block size in the DL and UL is the same
        FTM_WCDMA_BER_RMC_Type384kbps_Symmetric = 5		//!<' RMC 384 kbps channel, block size in the DL and UL is the same

        // Note: For first 3 data rate enumeration, UL CRC bits are looped back from DL
        // Note: For last  3 data rate enumeration, UL CRC is valid and computed based on Rx data bits
    }

    /*===========================================================================*/
    /**
    enum for WCDMA non-signaling Power Algorithm types
    */
    /*===========================================================================*/
    public enum FTM_WCDMA_BER_PCA_Type_Enum
    {
        FTM_WCDMA_BER_PCA_Type_Alg1 = 0,	//!<' Power control algorithm 1
        FTM_WCDMA_BER_PCA_Type_Alg2 = 1		//!<' Power control algorithm 2
    }

    /*===========================================================================*/
    /**
    enum for WCDMA non-signaling Power Algorithm types
    */
    /*===========================================================================*/
    public enum FTM_WCDMA_BER_PCA_Size_Enum
    {
        FTM_WCDMA_BER_PCA_Size_1dB = 0,	//!<' 1dB for power control algorithm
        FTM_WCDMA_BER_PCA_Size_2dB = 1		//!<' 2dB for power control algorithm

    }

    public enum WIFI_CHIP_TYPE
    {
        NULL_CHIP_TYPE,
        WIFI_WCN_3610,
        WIFI_WCN_3615,
        WIFI_WCN_3620,
        WIFI_WCN_3660,
        WIFI_WCN_3680

    }

    public enum HT_MODE
    {
        No_HT = 0,
        HT20,
        HT40_ADD,
        HT40_SUB,
        CCK,
        VHT20,
        VHT40_ADD,
        VHT40_SUB,
        VHT80_0,
        VHT80_1,
        VHT80_2,
        VHT80_3
    };

    public enum TX_Data_Rate_6174
    {
        TX_RATE_1Mbps_L = 0,
        TX_RATE_2Mbps_L,
        TX_RATE_2Mbps_S,
        TX_RATE_5_5Mbps_L,
        TX_RATE_5_5Mbps_S,
        TX_RATE_11Mbps_L,
        TX_RATE_11Mbps_S,
        TX_RATE_6Mbps = 8,
        TX_RATE_9Mbps,
        TX_RATE_12Mbps,
        TX_RATE_18Mbps,
        TX_RATE_24Mbps,
        TX_RATE_36Mbps,
        TX_RATE_48Mbps,
        TX_RATE_54Mbps,
        TX_RATE_MCS_0_20,
        TX_RATE_MCS_1_20,
        TX_RATE_MCS_2_20,
        TX_RATE_MCS_3_20,
        TX_RATE_MCS_4_20,
        TX_RATE_MCS_5_20,
        TX_RATE_MCS_6_20,
        TX_RATE_MCS_7_20,
        TX_RATE_MCS_0_40,
        TX_RATE_MCS_1_40,
        TX_RATE_MCS_2_40,
        TX_RATE_MCS_3_40,
        TX_RATE_MCS_4_40,
        TX_RATE_MCS_5_40,
        TX_RATE_MCS_6_40,
        TX_RATE_MCS_7_40,
        TX_RATE_MCS_8_20,
        TX_RATE_MCS_9_20,
        TX_RATE_MCS_10_20,
        TX_RATE_MCS_11_20,
        TX_RATE_MCS_12_20,
        TX_RATE_MCS_13_20,
        TX_RATE_MCS_14_20,
        TX_RATE_MCS_15_20,
        TX_RATE_MCS_8_40,
        TX_RATE_MCS_9_40,
        TX_RATE_MCS_10_40,
        TX_RATE_MCS_11_40,
        TX_RATE_MCS_12_40,
        TX_RATE_MCS_13_40,
        TX_RATE_MCS_14_40,
        TX_RATE_MCS_15_40,
        TX_RATE_MCS_16_20,
        TX_RATE_MCS_17_20,
        TX_RATE_MCS_18_20,
        TX_RATE_MCS_19_20,
        TX_RATE_MCS_20_20,
        TX_RATE_MCS_21_20,
        TX_RATE_MCS_22_20,
        TX_RATE_MCS_23_20,
        TX_RATE_MCS_16_40,
        TX_RATE_MCS_17_40,
        TX_RATE_MCS_18_40,
        TX_RATE_MCS_19_40,
        TX_RATE_MCS_20_40,
        TX_RATE_MCS_21_40,
        TX_RATE_MCS_22_40,
        TX_RATE_MCS_23_40,
        TX_RATE_AC_MCS_0_20,
        TX_RATE_AC_MCS_1_20,
        TX_RATE_AC_MCS_2_20,
        TX_RATE_AC_MCS_3_20,
        TX_RATE_AC_MCS_4_20,
        TX_RATE_AC_MCS_5_20,
        TX_RATE_AC_MCS_6_20,
        TX_RATE_AC_MCS_7_20,
        TX_RATE_AC_MCS_8_20,
        TX_RATE_AC_MCS_9_20,
        TX_RATE_AC_MCS_0_40 = 76,
        TX_RATE_AC_MCS_1_40,
        TX_RATE_AC_MCS_2_40,
        TX_RATE_AC_MCS_3_40,
        TX_RATE_AC_MCS_4_40,
        TX_RATE_AC_MCS_5_40,
        TX_RATE_AC_MCS_6_40,
        TX_RATE_AC_MCS_7_40,
        TX_RATE_AC_MCS_8_40,
        TX_RATE_AC_MCS_9_40,
        TX_RATE_AC_MCS_0_80 = 88,
        TX_RATE_AC_MCS_1_80,
        TX_RATE_AC_MCS_2_80,
        TX_RATE_AC_MCS_3_80,
        TX_RATE_AC_MCS_4_80,
        TX_RATE_AC_MCS_5_80,
        TX_RATE_AC_MCS_6_80,
        TX_RATE_AC_MCS_7_80,
        TX_RATE_AC_MCS_8_80,
        TX_RATE_AC_MCS_9_80,
        TX_RATE_AC_MCS_10_20 = 100,
        TX_RATE_AC_MCS_11_20,
        TX_RATE_AC_MCS_12_20,
        TX_RATE_AC_MCS_13_20,
        TX_RATE_AC_MCS_14_20,
        TX_RATE_AC_MCS_15_20,
        TX_RATE_AC_MCS_16_20,
        TX_RATE_AC_MCS_17_20,
        TX_RATE_AC_MCS_18_20,
        TX_RATE_AC_MCS_19_20,
        TX_RATE_AC_MCS_10_40 = 112,
        TX_RATE_AC_MCS_11_40,
        TX_RATE_AC_MCS_12_40,
        TX_RATE_AC_MCS_13_40,
        TX_RATE_AC_MCS_14_40,
        TX_RATE_AC_MCS_15_40,
        TX_RATE_AC_MCS_16_40,
        TX_RATE_AC_MCS_17_40,
        TX_RATE_AC_MCS_18_40,
        TX_RATE_AC_MCS_19_40,
        TX_RATE_AC_MCS_10_80 = 124,
        TX_RATE_AC_MCS_11_80,
        TX_RATE_AC_MCS_12_80,
        TX_RATE_AC_MCS_13_80,
        TX_RATE_AC_MCS_14_80,
        TX_RATE_AC_MCS_15_80,
        TX_RATE_AC_MCS_16_80,
        TX_RATE_AC_MCS_17_80,
        TX_RATE_AC_MCS_18_80,
        TX_RATE_AC_MCS_19_80,
        TX_RATE_AC_MCS_20_20 = 136,
        TX_RATE_AC_MCS_21_20,
        TX_RATE_AC_MCS_22_20,
        TX_RATE_AC_MCS_23_20,
        TX_RATE_AC_MCS_24_20,
        TX_RATE_AC_MCS_25_20,
        TX_RATE_AC_MCS_26_20,
        TX_RATE_AC_MCS_27_20,
        TX_RATE_AC_MCS_28_20,
        TX_RATE_AC_MCS_29_20,
        TX_RATE_AC_MCS_20_40 = 148,
        TX_RATE_AC_MCS_21_40,
        TX_RATE_AC_MCS_22_40,
        TX_RATE_AC_MCS_23_40,
        TX_RATE_AC_MCS_24_40,
        TX_RATE_AC_MCS_25_40,
        TX_RATE_AC_MCS_26_40,
        TX_RATE_AC_MCS_27_40,
        TX_RATE_AC_MCS_28_40,
        TX_RATE_AC_MCS_29_40,
        TX_RATE_AC_MCS_20_80 = 160,
        TX_RATE_AC_MCS_21_80,
        TX_RATE_AC_MCS_22_80,
        TX_RATE_AC_MCS_23_80,
        TX_RATE_AC_MCS_24_80,
        TX_RATE_AC_MCS_25_80,
        TX_RATE_AC_MCS_26_80,
        TX_RATE_AC_MCS_27_80,
        TX_RATE_AC_MCS_28_80,
        TX_RATE_AC_MCS_29_80,
        TX_RATE_AC_MCS_30_20 = 192,
        TX_RATE_AC_MCS_31_20,
        TX_RATE_AC_MCS_32_20,
        TX_RATE_AC_MCS_33_20,
        TX_RATE_AC_MCS_34_20,
        TX_RATE_AC_MCS_35_20,
        TX_RATE_AC_MCS_36_20,
        TX_RATE_AC_MCS_37_20,
        TX_RATE_AC_MCS_38_20,
        TX_RATE_AC_MCS_39_20,
        TX_RATE_AC_MCS_30_40,
        TX_RATE_AC_MCS_31_40,
        TX_RATE_AC_MCS_32_40,
        TX_RATE_AC_MCS_33_40,
        TX_RATE_AC_MCS_34_40,
        TX_RATE_AC_MCS_35_40,
        TX_RATE_AC_MCS_36_40,
        TX_RATE_AC_MCS_37_40,
        TX_RATE_AC_MCS_38_40,
        TX_RATE_AC_MCS_39_40,
        TX_RATE_AC_MCS_30_80,
        TX_RATE_AC_MCS_31_80,
        TX_RATE_AC_MCS_32_80,
        TX_RATE_AC_MCS_33_80,
        TX_RATE_AC_MCS_34_80,
        TX_RATE_AC_MCS_35_80,
        TX_RATE_AC_MCS_36_80,
        TX_RATE_AC_MCS_37_80,
        TX_RATE_AC_MCS_38_80,
        TX_RATE_AC_MCS_39_80,
        TX_RATE_MCS_24_20 = 256,
        TX_RATE_MCS_25_20,
        TX_RATE_MCS_26_20,
        TX_RATE_MCS_27_20,
        TX_RATE_MCS_28_20,
        TX_RATE_MCS_29_20,
        TX_RATE_MCS_30_20,
        TX_RATE_MCS_31_20,
        TX_RATE_MCS_24_40,
        TX_RATE_MCS_25_40,
        TX_RATE_MCS_26_40,
        TX_RATE_MCS_27_40,
        TX_RATE_MCS_28_40,
        TX_RATE_MCS_29_40,
        TX_RATE_MCS_30_40,
        TX_RATE_MCS_31_40
    };

    public enum RX_Data_Rate_6174
    {
        RX_RATE_1Mbps_L = 0,
        RX_RATE_2Mbps_L,
        RX_RATE_2Mbps_S,
        RX_RATE_5_5Mbps_L,
        RX_RATE_5_5Mbps_S,
        RX_RATE_11Mbps_L,
        RX_RATE_11Mbps_S,
        RX_RATE_6Mbps,
        RX_RATE_9Mbps,
        RX_RATE_12Mbps,
        RX_RATE_18Mbps,
        RX_RATE_24Mbps,
        RX_RATE_36Mbps,
        RX_RATE_48Mbps,
        RX_RATE_54Mbps,
        RX_RATE_MCS_0_20,
        RX_RATE_MCS_1_20,
        RX_RATE_MCS_2_20,
        RX_RATE_MCS_3_20,
        RX_RATE_MCS_4_20,
        RX_RATE_MCS_5_20,
        RX_RATE_MCS_6_20,
        RX_RATE_MCS_7_20,
        RX_RATE_MCS_0_40,
        RX_RATE_MCS_1_40,
        RX_RATE_MCS_2_40,
        RX_RATE_MCS_3_40,
        RX_RATE_MCS_4_40,
        RX_RATE_MCS_5_40,
        RX_RATE_MCS_6_40,
        RX_RATE_MCS_7_40,
        RX_RATE_AC_MCS_0_20,
        RX_RATE_AC_MCS_1_20,
        RX_RATE_AC_MCS_2_20,
        RX_RATE_AC_MCS_3_20,
        RX_RATE_AC_MCS_4_20,
        RX_RATE_AC_MCS_5_20,
        RX_RATE_AC_MCS_6_20,
        RX_RATE_AC_MCS_7_20,
        RX_RATE_AC_MCS_8_20,
        RX_RATE_AC_MCS_9_20,
        RX_RATE_AC_MCS_0_40,
        RX_RATE_AC_MCS_1_40,
        RX_RATE_AC_MCS_2_40,
        RX_RATE_AC_MCS_3_40,
        RX_RATE_AC_MCS_4_40,
        RX_RATE_AC_MCS_5_40,
        RX_RATE_AC_MCS_6_40,
        RX_RATE_AC_MCS_7_40,
        RX_RATE_AC_MCS_8_40,
        RX_RATE_AC_MCS_9_40,
        RX_RATE_AC_MCS_0_80,
        RX_RATE_AC_MCS_1_80,
        RX_RATE_AC_MCS_2_80,
        RX_RATE_AC_MCS_3_80,
        RX_RATE_AC_MCS_4_80,
        RX_RATE_AC_MCS_5_80,
        RX_RATE_AC_MCS_6_80,
        RX_RATE_AC_MCS_7_80,
        RX_RATE_AC_MCS_8_80,
        RX_RATE_AC_MCS_9_80,
        RX_RATE_MCS_8_20,
        RX_RATE_MCS_9_20,
        RX_RATE_MCS_10_20,
        RX_RATE_MCS_11_20,
        RX_RATE_MCS_12_20,
        RX_RATE_MCS_13_20,
        RX_RATE_MCS_14_20,
        RX_RATE_MCS_15_20,
        RX_RATE_MCS_8_40,
        RX_RATE_MCS_9_40,
        RX_RATE_MCS_10_40,
        RX_RATE_MCS_11_40,
        RX_RATE_MCS_12_40,
        RX_RATE_MCS_13_40,
        RX_RATE_MCS_14_40,
        RX_RATE_MCS_15_40,
        RX_RATE_AC_MCS_10_20,
        RX_RATE_AC_MCS_11_20,
        RX_RATE_AC_MCS_12_20,
        RX_RATE_AC_MCS_13_20,
        RX_RATE_AC_MCS_14_20,
        RX_RATE_AC_MCS_15_20,
        RX_RATE_AC_MCS_16_20,
        RX_RATE_AC_MCS_17_20,
        RX_RATE_AC_MCS_18_20,
        RX_RATE_AC_MCS_19_20,
        RX_RATE_AC_MCS_10_40,
        RX_RATE_AC_MCS_11_40,
        RX_RATE_AC_MCS_12_40,
        RX_RATE_AC_MCS_13_40,
        RX_RATE_AC_MCS_14_40,
        RX_RATE_AC_MCS_15_40,
        RX_RATE_AC_MCS_16_40,
        RX_RATE_AC_MCS_17_40,
        RX_RATE_AC_MCS_18_40,
        RX_RATE_AC_MCS_19_40,
        RX_RATE_AC_MCS_10_80,
        RX_RATE_AC_MCS_11_80,
        RX_RATE_AC_MCS_12_80,
        RX_RATE_AC_MCS_13_80,
        RX_RATE_AC_MCS_14_80,
        RX_RATE_AC_MCS_15_80,
        RX_RATE_AC_MCS_16_80,
        RX_RATE_AC_MCS_17_80,
        RX_RATE_AC_MCS_18_80,
        RX_RATE_AC_MCS_19_80,
        RX_RATE_MCS_16_20,
        RX_RATE_MCS_17_20,
        RX_RATE_MCS_18_20,
        RX_RATE_MCS_19_20,
        RX_RATE_MCS_20_20,
        RX_RATE_MCS_21_20,
        RX_RATE_MCS_22_20,
        RX_RATE_MCS_23_20,
        RX_RATE_MCS_16_40,
        RX_RATE_MCS_17_40,
        RX_RATE_MCS_18_40,
        RX_RATE_MCS_19_40,
        RX_RATE_MCS_20_40,
        RX_RATE_MCS_21_40,
        RX_RATE_MCS_22_40,
        RX_RATE_MCS_23_40,
        RX_RATE_AC_MCS_20_20,
        RX_RATE_AC_MCS_21_20,
        RX_RATE_AC_MCS_22_20,
        RX_RATE_AC_MCS_23_20,
        RX_RATE_AC_MCS_24_20,
        RX_RATE_AC_MCS_25_20,
        RX_RATE_AC_MCS_26_20,
        RX_RATE_AC_MCS_27_20,
        RX_RATE_AC_MCS_28_20,
        RX_RATE_AC_MCS_29_20,
        RX_RATE_AC_MCS_20_40,
        RX_RATE_AC_MCS_21_40,
        RX_RATE_AC_MCS_22_40,
        RX_RATE_AC_MCS_23_40,
        RX_RATE_AC_MCS_24_40,
        RX_RATE_AC_MCS_25_40,
        RX_RATE_AC_MCS_26_40,
        RX_RATE_AC_MCS_27_40,
        RX_RATE_AC_MCS_28_40,
        RX_RATE_AC_MCS_29_40,
        RX_RATE_AC_MCS_20_80,
        RX_RATE_AC_MCS_21_80,
        RX_RATE_AC_MCS_22_80,
        RX_RATE_AC_MCS_23_80,
        RX_RATE_AC_MCS_24_80,
        RX_RATE_AC_MCS_25_80,
        RX_RATE_AC_MCS_26_80,
        RX_RATE_AC_MCS_27_80,
        RX_RATE_AC_MCS_28_80,
        RX_RATE_AC_MCS_29_80,
        RX_RATE_AC_MCS_30_20,
        RX_RATE_AC_MCS_31_20,
        RX_RATE_AC_MCS_32_20,
        RX_RATE_AC_MCS_33_20,
        RX_RATE_AC_MCS_34_20,
        RX_RATE_AC_MCS_35_20,
        RX_RATE_AC_MCS_36_20,
        RX_RATE_AC_MCS_37_20,
        RX_RATE_AC_MCS_38_20,
        RX_RATE_AC_MCS_39_20,
        RX_RATE_AC_MCS_30_40,
        RX_RATE_AC_MCS_31_40,
        RX_RATE_AC_MCS_32_40,
        RX_RATE_AC_MCS_33_40,
        RX_RATE_AC_MCS_34_40,
        RX_RATE_AC_MCS_35_40,
        RX_RATE_AC_MCS_36_40,
        RX_RATE_AC_MCS_37_40,
        RX_RATE_AC_MCS_38_40,
        RX_RATE_AC_MCS_39_40,
        RX_RATE_AC_MCS_30_80,
        RX_RATE_AC_MCS_31_80,
        RX_RATE_AC_MCS_32_80,
        RX_RATE_AC_MCS_33_80,
        RX_RATE_AC_MCS_34_80,
        RX_RATE_AC_MCS_35_80,
        RX_RATE_AC_MCS_36_80,
        RX_RATE_AC_MCS_37_80,
        RX_RATE_AC_MCS_38_80,
        RX_RATE_AC_MCS_39_80,
        RX_RATE_MCS_24_20 = 263,
        RX_RATE_MCS_25_20,
        RX_RATE_MCS_26_20,
        RX_RATE_MCS_27_20,
        RX_RATE_MCS_28_20,
        RX_RATE_MCS_29_20,
        RX_RATE_MCS_30_20,
        RX_RATE_MCS_31_20,
        RX_RATE_MCS_24_40,
        RX_RATE_MCS_25_40,
        RX_RATE_MCS_26_40,
        RX_RATE_MCS_27_40,
        RX_RATE_MCS_28_40,
        RX_RATE_MCS_29_40,
        RX_RATE_MCS_30_40,
        RX_RATE_MCS_31_40
    };

    public enum TX_DATA_RATE_36XX
    {
        HAL_PHY_RATE_11B_LONG_1_MBPS,    // 0
        HAL_PHY_RATE_11B_LONG_2_MBPS,
        HAL_PHY_RATE_11B_LONG_5_5_MBPS,
        HAL_PHY_RATE_11B_LONG_11_MBPS,
        HAL_PHY_RATE_11B_SHORT_2_MBPS,
        HAL_PHY_RATE_11B_SHORT_5_5_MBPS,
        HAL_PHY_RATE_11B_SHORT_11_MBPS,  //6
                                         //	--- Spica_Virgo 11A 20MHz Rates ---
        HAL_PHY_RATE_11A_6_MBPS,        // 7
        HAL_PHY_RATE_11A_9_MBPS,
        HAL_PHY_RATE_11A_12_MBPS,
        HAL_PHY_RATE_11A_18_MBPS,
        HAL_PHY_RATE_11A_24_MBPS,
        HAL_PHY_RATE_11A_36_MBPS,
        HAL_PHY_RATE_11A_48_MBPS,
        HAL_PHY_RATE_11A_54_MBPS,       // 14
                                        //	--- 11A 20MHz Rates ---
        HAL_PHY_RATE_11A_DUP_6_MBPS,
        HAL_PHY_RATE_11A_DUP_9_MBPS,
        HAL_PHY_RATE_11A_DUP_12_MBPS,
        HAL_PHY_RATE_11A_DUP_18_MBPS,
        HAL_PHY_RATE_11A_DUP_24_MBPS,
        HAL_PHY_RATE_11A_DUP_36_MBPS,
        HAL_PHY_RATE_11A_DUP_48_MBPS,
        HAL_PHY_RATE_11A_DUP_54_MBPS,
        //	--- MCS Index #0-7 (20MHz) ---
        HAL_PHY_RATE_MCS_1NSS_6_5_MBPS,   // 23
        HAL_PHY_RATE_MCS_1NSS_13_MBPS,
        HAL_PHY_RATE_MCS_1NSS_19_5_MBPS,
        HAL_PHY_RATE_MCS_1NSS_26_MBPS,
        HAL_PHY_RATE_MCS_1NSS_39_MBPS,
        HAL_PHY_RATE_MCS_1NSS_52_MBPS,
        HAL_PHY_RATE_MCS_1NSS_58_5_MBPS,
        HAL_PHY_RATE_MCS_1NSS_65_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_7_2_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_14_4_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_21_7_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_28_9_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_43_3_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_57_8_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_65_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_72_2_MBPS,  // 38
                                                //	--- MCS Index #0-7 (40MHz) ---
        HAL_PHY_RATE_MCS_1NSS_CB_13_5_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_27_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_40_5_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_54_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_81_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_108_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_121_5_MBPS,
        HAL_PHY_RATE_MCS_1NSS_CB_135_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_15_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_30_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_45_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_60_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_90_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_120_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_135_MBPS,
        HAL_PHY_RATE_MCS_1NSS_MM_SG_CB_150_MBPS
    }

    public enum TX_Data_Rate
    {
        TX_RATE_1Mbps_L = 0,
        TX_RATE_2Mbps_L,
        TX_RATE_2Mbps_S,
        TX_RATE_5_5Mbps_L,
        TX_RATE_5_5Mbps_S,
        TX_RATE_11Mbps_L,
        TX_RATE_11Mbps_S,
        TX_RATE_6Mbps = 8,
        TX_RATE_9Mbps,
        TX_RATE_12Mbps,
        TX_RATE_18Mbps,
        TX_RATE_24Mbps,
        TX_RATE_36Mbps,
        TX_RATE_48Mbps,
        TX_RATE_54Mbps,
        TX_RATE_MCS_0_20,
        TX_RATE_MCS_1_20,
        TX_RATE_MCS_2_20,
        TX_RATE_MCS_3_20,
        TX_RATE_MCS_4_20,
        TX_RATE_MCS_5_20,
        TX_RATE_MCS_6_20,
        TX_RATE_MCS_7_20,
        TX_RATE_MCS_0_40,
        TX_RATE_MCS_1_40,
        TX_RATE_MCS_2_40,
        TX_RATE_MCS_3_40,
        TX_RATE_MCS_4_40,
        TX_RATE_MCS_5_40,
        TX_RATE_MCS_6_40,
        TX_RATE_MCS_7_40,
        TX_RATE_MCS_8_20,
        TX_RATE_MCS_9_20,
        TX_RATE_MCS_10_20,
        TX_RATE_MCS_11_20,
        TX_RATE_MCS_12_20,
        TX_RATE_MCS_13_20,
        TX_RATE_MCS_14_20,
        TX_RATE_MCS_15_20,
        TX_RATE_MCS_8_40,
        TX_RATE_MCS_9_40,
        TX_RATE_MCS_10_40,
        TX_RATE_MCS_11_40,
        TX_RATE_MCS_12_40,
        TX_RATE_MCS_13_40,
        TX_RATE_MCS_14_40,
        TX_RATE_MCS_15_40,
        TX_RATE_MCS_16_20,
        TX_RATE_MCS_17_20,
        TX_RATE_MCS_18_20,
        TX_RATE_MCS_19_20,
        TX_RATE_MCS_20_20,
        TX_RATE_MCS_21_20,
        TX_RATE_MCS_22_20,
        TX_RATE_MCS_23_20,
        TX_RATE_MCS_16_40,
        TX_RATE_MCS_17_40,
        TX_RATE_MCS_18_40,
        TX_RATE_MCS_19_40,
        TX_RATE_MCS_20_40,
        TX_RATE_MCS_21_40,
        TX_RATE_MCS_22_40,
        TX_RATE_MCS_23_40,
        TX_RATE_AC_MCS_0_20,
        TX_RATE_AC_MCS_1_20,
        TX_RATE_AC_MCS_2_20,
        TX_RATE_AC_MCS_3_20,
        TX_RATE_AC_MCS_4_20,
        TX_RATE_AC_MCS_5_20,
        TX_RATE_AC_MCS_6_20,
        TX_RATE_AC_MCS_7_20,
        TX_RATE_AC_MCS_8_20,
        TX_RATE_AC_MCS_9_20,
        TX_RATE_AC_MCS_0_40 = 76,
        TX_RATE_AC_MCS_1_40,
        TX_RATE_AC_MCS_2_40,
        TX_RATE_AC_MCS_3_40,
        TX_RATE_AC_MCS_4_40,
        TX_RATE_AC_MCS_5_40,
        TX_RATE_AC_MCS_6_40,
        TX_RATE_AC_MCS_7_40,
        TX_RATE_AC_MCS_8_40,
        TX_RATE_AC_MCS_9_40,
        TX_RATE_AC_MCS_0_80 = 88,
        TX_RATE_AC_MCS_1_80,
        TX_RATE_AC_MCS_2_80,
        TX_RATE_AC_MCS_3_80,
        TX_RATE_AC_MCS_4_80,
        TX_RATE_AC_MCS_5_80,
        TX_RATE_AC_MCS_6_80,
        TX_RATE_AC_MCS_7_80,
        TX_RATE_AC_MCS_8_80,
        TX_RATE_AC_MCS_9_80,
        TX_RATE_AC_MCS_10_20 = 100,
        TX_RATE_AC_MCS_11_20,
        TX_RATE_AC_MCS_12_20,
        TX_RATE_AC_MCS_13_20,
        TX_RATE_AC_MCS_14_20,
        TX_RATE_AC_MCS_15_20,
        TX_RATE_AC_MCS_16_20,
        TX_RATE_AC_MCS_17_20,
        TX_RATE_AC_MCS_18_20,
        TX_RATE_AC_MCS_19_20,
        TX_RATE_AC_MCS_10_40 = 112,
        TX_RATE_AC_MCS_11_40,
        TX_RATE_AC_MCS_12_40,
        TX_RATE_AC_MCS_13_40,
        TX_RATE_AC_MCS_14_40,
        TX_RATE_AC_MCS_15_40,
        TX_RATE_AC_MCS_16_40,
        TX_RATE_AC_MCS_17_40,
        TX_RATE_AC_MCS_18_40,
        TX_RATE_AC_MCS_19_40,
        TX_RATE_AC_MCS_10_80 = 124,
        TX_RATE_AC_MCS_11_80,
        TX_RATE_AC_MCS_12_80,
        TX_RATE_AC_MCS_13_80,
        TX_RATE_AC_MCS_14_80,
        TX_RATE_AC_MCS_15_80,
        TX_RATE_AC_MCS_16_80,
        TX_RATE_AC_MCS_17_80,
        TX_RATE_AC_MCS_18_80,
        TX_RATE_AC_MCS_19_80,
        TX_RATE_AC_MCS_20_20 = 136,
        TX_RATE_AC_MCS_21_20,
        TX_RATE_AC_MCS_22_20,
        TX_RATE_AC_MCS_23_20,
        TX_RATE_AC_MCS_24_20,
        TX_RATE_AC_MCS_25_20,
        TX_RATE_AC_MCS_26_20,
        TX_RATE_AC_MCS_27_20,
        TX_RATE_AC_MCS_28_20,
        TX_RATE_AC_MCS_29_20,
        TX_RATE_AC_MCS_20_40 = 148,
        TX_RATE_AC_MCS_21_40,
        TX_RATE_AC_MCS_22_40,
        TX_RATE_AC_MCS_23_40,
        TX_RATE_AC_MCS_24_40,
        TX_RATE_AC_MCS_25_40,
        TX_RATE_AC_MCS_26_40,
        TX_RATE_AC_MCS_27_40,
        TX_RATE_AC_MCS_28_40,
        TX_RATE_AC_MCS_29_40,
        TX_RATE_AC_MCS_20_80 = 160,
        TX_RATE_AC_MCS_21_80,
        TX_RATE_AC_MCS_22_80,
        TX_RATE_AC_MCS_23_80,
        TX_RATE_AC_MCS_24_80,
        TX_RATE_AC_MCS_25_80,
        TX_RATE_AC_MCS_26_80,
        TX_RATE_AC_MCS_27_80,
        TX_RATE_AC_MCS_28_80,
        TX_RATE_AC_MCS_29_80,
        TX_RATE_AC_MCS_30_20 = 192,
        TX_RATE_AC_MCS_31_20,
        TX_RATE_AC_MCS_32_20,
        TX_RATE_AC_MCS_33_20,
        TX_RATE_AC_MCS_34_20,
        TX_RATE_AC_MCS_35_20,
        TX_RATE_AC_MCS_36_20,
        TX_RATE_AC_MCS_37_20,
        TX_RATE_AC_MCS_38_20,
        TX_RATE_AC_MCS_39_20,
        TX_RATE_AC_MCS_30_40,
        TX_RATE_AC_MCS_31_40,
        TX_RATE_AC_MCS_32_40,
        TX_RATE_AC_MCS_33_40,
        TX_RATE_AC_MCS_34_40,
        TX_RATE_AC_MCS_35_40,
        TX_RATE_AC_MCS_36_40,
        TX_RATE_AC_MCS_37_40,
        TX_RATE_AC_MCS_38_40,
        TX_RATE_AC_MCS_39_40,
        TX_RATE_AC_MCS_30_80,
        TX_RATE_AC_MCS_31_80,
        TX_RATE_AC_MCS_32_80,
        TX_RATE_AC_MCS_33_80,
        TX_RATE_AC_MCS_34_80,
        TX_RATE_AC_MCS_35_80,
        TX_RATE_AC_MCS_36_80,
        TX_RATE_AC_MCS_37_80,
        TX_RATE_AC_MCS_38_80,
        TX_RATE_AC_MCS_39_80,
        TX_RATE_MCS_24_20 = 256,
        TX_RATE_MCS_25_20,
        TX_RATE_MCS_26_20,
        TX_RATE_MCS_27_20,
        TX_RATE_MCS_28_20,
        TX_RATE_MCS_29_20,
        TX_RATE_MCS_30_20,
        TX_RATE_MCS_31_20,
        TX_RATE_MCS_24_40,
        TX_RATE_MCS_25_40,
        TX_RATE_MCS_26_40,
        TX_RATE_MCS_27_40,
        TX_RATE_MCS_28_40,
        TX_RATE_MCS_29_40,
        TX_RATE_MCS_30_40,
        TX_RATE_MCS_31_40
    }
}