﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pmis.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://pmis.sangah.com")]
        public string pmis_api_url {
            get {
                return ((string)(this["pmis_api_url"]));
            }
            set {
                this["pmis_api_url"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GLB_PMIS")]
        public string pmis_project_code {
            get {
                return ((string)(this["pmis_project_code"]));
            }
            set {
                this["pmis_project_code"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string pmis_auth_key {
            get {
                return ((string)(this["pmis_auth_key"]));
            }
            set {
                this["pmis_auth_key"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>공통</string>
  <string>건축</string>
  <string>기계</string>
  <string>토목</string>
  <string>조경</string>
  <string>전기</string>
  <string>통신</string>
  <string>기타</string>
  <string>소방</string>
  <string>관급자재</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection register_discipline {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["register_discipline"]));
            }
            set {
                this["register_discipline"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>승인용</string>
  <string>공사용</string>
  <string>최종용</string>
  <string>참고용</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection register_status {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["register_status"]));
            }
            set {
                this["register_status"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>4,1. MAIN PAGE,17808,17804</string>\r\n  <string>4,1. 계약관리,17776,17587</stri" +
            "ng>\r\n  <string>4,1. 공정현황,17771,17589</string>\r\n  <string>4,1. 공지사항,17782,17781</" +
            "string>\r\n  <string>4,1. 문서일반,17811,17810</string>\r\n  <string>4,1. 사업현황,17764,175" +
            "86</string>\r\n  <string>4,1. 시공업무보고,17780,17591</string>\r\n  <string>4,1. 시스템 개요,1" +
            "7805,3201</string>\r\n  <string>4,1. 품질관리,17767,17590</string>\r\n  <string>4,2. 공통기" +
            "능,17809,17804</string>\r\n  <string>4,2. 문서관리,17812,17810</string>\r\n  <string>4,2." +
            " 분류체계,17772,17589</string>\r\n  <string>4,2. 사업일정,17783,17781</string>\r\n  <string>" +
            "4,2. 시스템 구성,17806,3201</string>\r\n  <string>4,2. 안전관리,17768,17590</string>\r\n  <st" +
            "ring>4,2. 조직현황,17765,17586</string>\r\n  <string>4,2. 하도급관리,17777,17587</string>\r\n" +
            "  <string>4,3-Months Shedule,475,474</string>\r\n  <string>4,3-Weeks Schedule,476," +
            "474</string>\r\n  <string>4,3. 공정계획관리,17773,17589</string>\r\n  <string>4,3. 비상연락망,1" +
            "7784,17781</string>\r\n  <string>4,3. 사업현안,17766,17586</string>\r\n  <string>4,3. 시스" +
            "템 시작하기,17807,3201</string>\r\n  <string>4,3. 원가(내역)관리,17778,17587</string>\r\n  <str" +
            "ing>4,3. 제출물관리,17813,17810</string>\r\n  <string>4,3. 환경관리,17769,17590</string>\r\n " +
            " <string>4,4. 공정진도관리,17774,17589</string>\r\n  <string>4,4. 기성관리,17779,17587</stri" +
            "ng>\r\n  <string>4,4. 설계자료,17814,17810</string>\r\n  <string>4,4. 시공공정사진,17770,17590" +
            "</string>\r\n  <string>4,4. 웹하드,17785,17781</string>\r\n  <string>4,5. CMIS 질의/응답,17" +
            "786,17781</string>\r\n  <string>4,5. 공정승인관리,17775,17589</string>\r\n  <string>4,5. 월" +
            "간시공보고,18104,17590</string>\r\n  <string>4,6. 주간시공보고,18124,17590</string>\r\n  <strin" +
            "g>4,A,19864,1208</string>\r\n  <string>5,A,19868,19866</string>\r\n  <string>4,A,198" +
            "65,1206</string>\r\n  <string>4,A  B,19869,1201</string>\r\n  <string>4,A  B,19870,1" +
            "201</string>\r\n  <string>4,Agreement contents management document,117,78</string>" +
            "\r\n  <string>5,Architectural,17628,507</string>\r\n  <string>5,Architectural,17636," +
            "508</string>\r\n  <string>5,Architectural,17620,506</string>\r\n  <string>5,Architec" +
            "tural(건축),17644,513</string>\r\n  <string>5,Architectural(건축),17652,514</string>\r\n" +
            "  <string>5,Architectural(건축),17660,515</string>\r\n  <string>5,Architectural(건축)," +
            "17668,517</string>\r\n  <string>5,Architecture,126,81</string>\r\n  <string>5,Archit" +
            "ecture,246,83</string>\r\n  <string>5,Architecture,240,82</string>\r\n  <string>6,Ar" +
            "chitecture (건축),142,136</string>\r\n  <string>6,Auxiliary equipment,451,132</strin" +
            "g>\r\n  <string>6,Auxiliary equipment,448,131</string>\r\n  <string>4,B,19867,1203</" +
            "string>\r\n  <string>4,B,19866,1204</string>\r\n  <string>4,Basic design drawing/doc" +
            ".,506,504</string>\r\n  <string>6,Boiler,446,131</string>\r\n  <string>6,Boiler,449," +
            "132</string>\r\n  <string>4,Change of design(설계변경도면/도서),515,504</string>\r\n  <strin" +
            "g>5,Civil,239,82</string>\r\n  <string>5,Civil,17630,507</string>\r\n  <string>5,Civ" +
            "il,245,83</string>\r\n  <string>5,Civil,17638,508</string>\r\n  <string>5,Civil,1762" +
            "2,506</string>\r\n  <string>5,Civil,125,81</string>\r\n  <string>5,Civil &amp; Archi" +
            ",430,423</string>\r\n  <string>5,Civil &amp; Archi,424,420</string>\r\n  <string>5,C" +
            "ivil &amp; Archi,440,439</string>\r\n  <string>6,Civil (토목),141,136</string>\r\n  <s" +
            "tring>5,Civil(토목),17646,513</string>\r\n  <string>5,Civil(토목),17654,514</string>\r\n" +
            "  <string>5,Civil(토목),17662,515</string>\r\n  <string>5,Civil(토목),17670,517</strin" +
            "g>\r\n  <string>6,Common (공통),137,136</string>\r\n  <string>2,Community(커뮤니티),502,20" +
            "00</string>\r\n  <string>4,Completion drawing(준공도면),517,504</string>\r\n  <string>3," +
            "Construction Change Direction,1209,1200</string>\r\n  <string>2,Construction Manag" +
            "ement(시공관리),52,2000</string>\r\n  <string>3,Construction details progress chart,47" +
            "4,52</string>\r\n  <string>3,Construction work report,72,14</string>\r\n  <string>2," +
            "Contract Management,17585,2000</string>\r\n  <string>4,Contract design drawing/doc" +
            ".,507,504</string>\r\n  <string>3,Contract document,1215,1200</string>\r\n  <string>" +
            "6,Contractor (시공사),452,134</string>\r\n  <string>5,Control,129,81</string>\r\n  <str" +
            "ing>5,Control,249,83</string>\r\n  <string>5,Control,243,82</string>\r\n  <string>4," +
            "Correction Action Request (CAR),83,76</string>\r\n  <string>4,Daily Health and Saf" +
            "ety Training Report,88,77</string>\r\n  <string>4,Daily environment inspection rep" +
            "ort,93,78</string>\r\n  <string>4,Daily environmental education report,94,78</stri" +
            "ng>\r\n  <string>4,Daily safety Inspection report,87,77</string>\r\n  <string>1,Data" +
            " Management,2000,0000</string>\r\n  <string>3,Deficiency Notice / Remedial Report," +
            "1201,1200</string>\r\n  <string>2,Design Management,503,2000</string>\r\n  <string>3" +
            ",Design VE,18004,503</string>\r\n  <string>4,Design VE/Data,18006,18004</string>\r\n" +
            "  <string>4,Design VE/Report,18005,18004</string>\r\n  <string>3,Design change doc" +
            "ument,505,503</string>\r\n  <string>4,Design change notice (DCN),509,505</string>\r" +
            "\n  <string>3,Design drawing/doc.,504,503</string>\r\n  <string>3,Design meeting(설계" +
            "회의),518,503</string>\r\n  <string>1,Document Management,1000,0000</string>\r\n  <str" +
            "ing>2,Documents &amp; Drawings,1200,1000</string>\r\n  <string>2,E-Book Management" +
            "(전자도서관리),3100,3000</string>\r\n  <string>5,Electrical/Communication,17641,508</str" +
            "ing>\r\n  <string>5,Electrical/Communication,17625,506</string>\r\n  <string>5,Elect" +
            "rical/Communication,17633,507</string>\r\n  <string>5,Electrical/Communication(전기/" +
            "통신),17657,514</string>\r\n  <string>5,Electrical/Communication(전기/통신),17665,515</s" +
            "tring>\r\n  <string>5,Electrical/Communication(전기/통신),17673,517</string>\r\n  <strin" +
            "g>5,Electrical/Communication(전기/통신),17649,513</string>\r\n  <string>5,Electricity," +
            "442,439</string>\r\n  <string>5,Electricity,242,82</string>\r\n  <string>5,Electrici" +
            "ty,432,423</string>\r\n  <string>5,Electricity,248,83</string>\r\n  <string>5,Electr" +
            "icity,426,420</string>\r\n  <string>5,Electricity,128,81</string>\r\n  <string>6,Ele" +
            "ctricity (전기),139,136</string>\r\n  <string>5,Electricity Power,428,420</string>\r\n" +
            "  <string>5,Electricity Power,434,423</string>\r\n  <string>5,Electricity Power,44" +
            "4,439</string>\r\n  <string>4,Enforcement design 100%(실시설계(100%)도면/도서),514,504</st" +
            "ring>\r\n  <string>4,Enforcement design 50%(실시설계(50%)도면/도서),513,504</string>\r\n  <s" +
            "tring>3,Environmental Management,78,155</string>\r\n  <string>4,Environmental Mana" +
            "gement Plan,92,78</string>\r\n  <string>4,Environmental visibility requirements,50" +
            "0,78</string>\r\n  <string>6,Equipment manufacturers (자재/장비 제조업체),453,134</string>" +
            "\r\n  <string>5,Etc.,244,82</string>\r\n  <string>5,Etc.,130,81</string>\r\n  <string>" +
            "5,Etc.,250,83</string>\r\n  <string>3,Etcetera,1199,100</string>\r\n  <string>3,Even" +
            "t Photos,472,52</string>\r\n  <string>4,Factory demolition work,17,15</string>\r\n  " +
            "<string>4,Fence installing construction,16,15</string>\r\n  <string>3,Field Instru" +
            "ction,1213,1200</string>\r\n  <string>4,Field change notification (FCN),17745,505<" +
            "/string>\r\n  <string>4,Field change request (FCR),512,505</string>\r\n  <string>5,F" +
            "ire,445,439</string>\r\n  <string>5,Fire ,429,420</string>\r\n  <string>5,Firefighti" +
            "ng,17642,508</string>\r\n  <string>5,Firefighting,17626,506</string>\r\n  <string>5," +
            "Firefighting,17634,507</string>\r\n  <string>5,Firefighting(소방),17666,515</string>" +
            "\r\n  <string>5,Firefighting(소방),17674,517</string>\r\n  <string>5,Firefighting(소방)," +
            "17650,513</string>\r\n  <string>5,Firefighting(소방),17658,514</string>\r\n  <string>4" +
            ",History of usge of environment preservation cost ,217,78</string>\r\n  <string>3," +
            "I. 시스템 개요,3201,3200</string>\r\n  <string>3,II.시스템공통,17804,3200</string>\r\n  <strin" +
            "g>3,III.사업일반,17586,3200</string>\r\n  <string>3,IV.계약/기성,17587,3200</string>\r\n  <s" +
            "tring>3,IX. 문서/자료,17810,3200</string>\r\n  <string>3,Imported Materials Inspection" +
            ",1207,1200</string>\r\n  <string>5,Information and Communication,431,423</string>\r" +
            "\n  <string>5,Information and Communication,425,420</string>\r\n  <string>5,Informa" +
            "tion and Communication,441,439</string>\r\n  <string>5,Initiation inspection bowel" +
            " management,251,80</string>\r\n  <string>3,Inspection,18784,100</string>\r\n  <strin" +
            "g>4,Inspection Level 2,18804,18784</string>\r\n  <string>4,Inspection Level 3,1886" +
            "4,18784</string>\r\n  <string>5,Inspection procedures / plans,131,80</string>\r\n  <" +
            "string>5,Landscaping,17639,508</string>\r\n  <string>5,Landscaping,17631,507</stri" +
            "ng>\r\n  <string>5,Landscaping,17623,506</string>\r\n  <string>5,Landscaping(조경),176" +
            "71,517</string>\r\n  <string>5,Landscaping(조경),17647,513</string>\r\n  <string>5,Lan" +
            "dscaping(조경),17663,515</string>\r\n  <string>5,Landscaping(조경),17655,514</string>\r" +
            "\n  <string>3,Letter,1101,100</string>\r\n  <string>5,Machine,17624,506</string>\r\n " +
            " <string>5,Machine,17640,508</string>\r\n  <string>5,Machine,17632,507</string>\r\n " +
            " <string>5,Machine,427,420</string>\r\n  <string>5,Machine,433,423</string>\r\n  <st" +
            "ring>5,Machine,443,439</string>\r\n  <string>5,Machine,127,81</string>\r\n  <string>" +
            "5,Machine,241,82</string>\r\n  <string>5,Machine,247,83</string>\r\n  <string>6,Mach" +
            "ine (기계),138,136</string>\r\n  <string>5,Machine(기계),17672,517</string>\r\n  <string" +
            ">5,Machine(기계),17656,514</string>\r\n  <string>5,Machine(기계),17664,515</string>\r\n " +
            " <string>5,Machine(기계),17648,513</string>\r\n  <string>4,Master Plan(사업계획),621,601" +
            "</string>\r\n  <string>3,Material Approved Request,1206,1200</string>\r\n  <string>3" +
            ",Materials for meeting,1214,1200</string>\r\n  <string>6,Measurement,140,136</stri" +
            "ng>\r\n  <string>3,Measures for delay,158,43</string>\r\n  <string>3,Measures for de" +
            "lay,60,52</string>\r\n  <string>3,Meeting Minutes,1103,100</string>\r\n  <string>4,M" +
            "inutes(회의록),511,518</string>\r\n  <string>3,Monthly foreground photo,115,52</strin" +
            "g>\r\n  <string>3,Non Conformance Report ,1202,1200</string>\r\n  <string>4,Nonconfo" +
            "rmity reports (NCR),82,76</string>\r\n  <string>4,Office Remodeling,18,15</string>" +
            "\r\n  <string>2,Official Documents,100,1000</string>\r\n  <string>4,On-site inspecti" +
            "on (ITP),81,76</string>\r\n  <string>3,Organization,178,21</string>\r\n  <string>5,O" +
            "ther,17627,506</string>\r\n  <string>5,Other,17643,508</string>\r\n  <string>5,Other" +
            ",17635,507</string>\r\n  <string>1,Other Management(기타관리),3000,0000</string>\r\n  <s" +
            "tring>4,Other construction,422,15</string>\r\n  <string>3,Other work report,75,14<" +
            "/string>\r\n  <string>5,Other(기타),17667,515</string>\r\n  <string>5,Other(기타),17675," +
            "517</string>\r\n  <string>5,Other(기타),17651,513</string>\r\n  <string>5,Other(기타),17" +
            "659,514</string>\r\n  <string>3,Permission,17824,21</string>\r\n  <string>3,Pre-cons" +
            "truction work report,15,14</string>\r\n  <string>2,Process Management(공정관리),43,200" +
            "0</string>\r\n  <string>3,Process photo,61,52</string>\r\n  <string>3,Production pro" +
            "cess photo,227,43</string>\r\n  <string>2,Project Management,21,2000</string>\r\n  <" +
            "string>3,Project Status,122,21</string>\r\n  <string>3,Project Status(사업일반),601,31" +
            "00</string>\r\n  <string>4,Promotional materials (홍보자료),17605,601</string>\r\n  <str" +
            "ing>4,Quality Diagnostic (품질진단),156,76</string>\r\n  <string>4,Quality Improvement" +
            " Program(QIP),80,76</string>\r\n  <string>3,Quality Management,76,155</string>\r\n  " +
            "<string>4,Quality Management Plan,79,76</string>\r\n  <string>5,Quality Manual (품질" +
            " 메뉴얼),134,85</string>\r\n  <string>5,Quality procedures (품질절차서),136,85</string>\r\n " +
            " <string>4,Quality reference room (품질 자료실),85,76</string>\r\n  <string>2,Quality/S" +
            "afety/Environment(품질/안전/환경),155,2000</string>\r\n  <string>2,Report Management(보고관" +
            "리),14,2000</string>\r\n  <string>4,Report material(보고자료),510,518</string>\r\n  <stri" +
            "ng>3,Request For Design Change,1212,1200</string>\r\n  <string>3,Request For Infor" +
            "mation,1211,1200</string>\r\n  <string>3,Request For Inspection,1208,1200</string>" +
            "\r\n  <string>3,Request for Information,1105,100</string>\r\n  <string>3,Safety Corr" +
            "ective Action Request ,1203,1200</string>\r\n  <string>3,Safety Management,77,155<" +
            "/string>\r\n  <string>4,Safety Management Plan,86,77</string>\r\n  <string>4,Safety " +
            "Resources,91,77</string>\r\n  <string>4,Safety intellectual,216,77</string>\r\n  <st" +
            "ring>4,Safety management usage,89,77</string>\r\n  <string>3,Site Memo,1104,100</s" +
            "tring>\r\n  <string>2,Stage &amp; Gate,19405,19404</string>\r\n  <string>4,Start con" +
            "struction drawing/doc.,508,504</string>\r\n  <string>5,Status of defects per compa" +
            "ny,133,80</string>\r\n  <string>4,Status of the event of a disaster,90,77</string>" +
            "\r\n  <string>5,Structural,17621,506</string>\r\n  <string>5,Structural,17637,508</s" +
            "tring>\r\n  <string>5,Structural,17629,507</string>\r\n  <string>5,Structural(구조),17" +
            "653,514</string>\r\n  <string>5,Structural(구조),17661,515</string>\r\n  <string>5,Str" +
            "uctural(구조),17669,517</string>\r\n  <string>5,Structural(구조),17645,513</string>\r\n " +
            " <string>3,Subcontract   Databank,18084,52</string>\r\n  <string>3,Subcontract App" +
            "roval Request,1205,1200</string>\r\n  <string>3,Submittal,1204,1200</string>\r\n  <s" +
            "tring>4,Supervision vacation.,116,68</string>\r\n  <string>4,Supervision work repo" +
            "rt,70,68</string>\r\n  <string>3,Supervision work report,68,14</string>\r\n  <string" +
            ">4,Supervision work report (Fire),231,68</string>\r\n  <string>4,Supervision work " +
            "report (Mechanical),232,68</string>\r\n  <string>4,Supervision work report(Civil &" +
            "amp; archi),230,68</string>\r\n  <string>4,Supervision work report(Electricity),23" +
            "3,68</string>\r\n  <string>4,Supervision work report(Information and Communicat,41" +
            "3,68</string>\r\n  <string>4,Supervision work report(N1),69,68</string>\r\n  <string" +
            ">4,Supervision work report(N2),238,68</string>\r\n  <string>4,Supervision work rep" +
            "ort(electric),234,68</string>\r\n  <string>3,Supervisor Official writing,455,14</s" +
            "tring>\r\n  <string>4,Supplier default disposal requests (SDDR),17746,505</string>" +
            "\r\n  <string>1,System Management,19404,0000</string>\r\n  <string>2,System Manual,3" +
            "200,3000</string>\r\n  <string>4,Technical Review Comments,423,75</string>\r\n  <str" +
            "ing>5,The-spot inspection report,132,80</string>\r\n  <string>3,Transmittal,18744," +
            "100</string>\r\n  <string>3,Transmittal For Approval,1210,1200</string>\r\n  <string" +
            ">6,Turbine,450,132</string>\r\n  <string>6,Turbine,447,131</string>\r\n  <string>3,V" +
            ".공정관리,17589,3200</string>\r\n  <string>3,VI.시공관리,17590,3200</string>\r\n  <string>3," +
            "VII.보고관리,17591,3200</string>\r\n  <string>3,VIII.커뮤니티,17781,3200</string>\r\n  <stri" +
            "ng>4,Waste Management document,95,78</string>\r\n  <string>4,Work order (Owner),42" +
            "0,75</string>\r\n  <string>4,Work order (Supervisor),439,75</string>\r\n  <string>4," +
            "Workflow Transmittal,18764,18744</string>\r\n  <string>4,Writing Official document" +
            " (Shinhan),456,455</string>\r\n  <string>3,건설사업관리 기록부,18346,18344</string>\r\n  <str" +
            "ing>3,건설사업관리 지시부,18347,18344</string>\r\n  <string>3,건설사업관리 지시부 조치,18348,18344</st" +
            "ring>\r\n  <string>3,과제개요,19406,19405</string>\r\n  <string>1,구매관리,17984,0000</strin" +
            "g>\r\n  <string>3,기간/자원/비용,19407,19405</string>\r\n  <string>3,기술검토의견서,18345,18344</" +
            "string>\r\n  <string>2,기자재제작사진,17985,17984</string>\r\n  <string>2,기초과학연구원 양식,18344," +
            "1000</string>\r\n  <string>3,마일스톤,19408,19405</string>\r\n  <string>3,분야별 업무일자,18364" +
            ",52</string>\r\n  <string>3,예상매출,19409,19405</string>\r\n  <string>2,테스트,18284,17984" +
            "</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection register_type {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["register_type"]));
            }
            set {
                this["register_type"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("register")]
        public string register_folder_uri {
            get {
                return ((string)(this["register_folder_uri"]));
            }
            set {
                this["register_folder_uri"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("data/archive.db")]
        public string sqlite_db_location {
            get {
                return ((string)(this["sqlite_db_location"]));
            }
            set {
                this["sqlite_db_location"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sqlite")]
        public string db_type {
            get {
                return ((string)(this["db_type"]));
            }
            set {
                this["db_type"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ko_KR")]
        public string language {
            get {
                return ((string)(this["language"]));
            }
            set {
                this["language"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pictures")]
        public string picture_folder_uri {
            get {
                return ((string)(this["picture_folder_uri"]));
            }
            set {
                this["picture_folder_uri"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Workflow</string>
  <string>Picture</string>
  <string>Issue</string>
  <string>Risk</string>
  <string>Contract</string>
  <string>Register</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection archive_types {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["archive_types"]));
            }
            set {
                this["archive_types"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("default")]
        public string current_profile {
            get {
                return ((string)(this["current_profile"]));
            }
            set {
                this["current_profile"] = value;
            }
        }
    }
}
