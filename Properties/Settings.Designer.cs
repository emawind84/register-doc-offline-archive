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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("test")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://dev.sangah.com")]
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
  <string>일반</string>
  <string>건축</string>
  <string>구조</string>
  <string>토목</string>
  <string>조경</string>
  <string>기계</string>
  <string>UT/환경</string>
  <string>소방기계</string>
  <string>전기</string>
  <string>통신</string>
  <string>소방전기</string>
  <string>기타</string>
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
  <string>승인</string>
  <string>조건부승인</string>
  <string>반려</string>
  <string>정보용</string>
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
            "tring>PMIS 자료분류</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계</string>\r\n  <string>PM" +
            "IS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류</string>\r\n  <string>PMIS 자료분류 &gt; 문서" +
            "분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 개산급 관리대장</string>\r\n  <string>PMIS 자료분류 &gt; 문서분" +
            "류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 건축 - 공정승인 첨부서류</string>\r\n  <string>PMIS 자료분류 &gt" +
            "; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 기계 - 공정승인 첨부서류</string>\r\n  <string>PMIS 자료분" +
            "류 &gt; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 소방기계 - 공정승인 첨부서류</string>\r\n  <string>P" +
            "MIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 소방전기 - 공정승인 첨부서류</string>\r\n  <s" +
            "tring>PMIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 전기 - 공정승인 첨부서류</string>\r" +
            "\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 공정승인 첨부서류 &gt; 통신 - 공정승인 첨부서류</str" +
            "ing>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 보고서 &gt; 공정현황보고</string>\r\n  <" +
            "string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 보고서 &gt; 공정현황보고 &gt; 월간공정보고</string>\r\n" +
            "  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공정 &gt; 보고서 &gt; 공정현황보고 &gt; 주간공정보고</string" +
            ">\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통</string>\r\n  <string>PMIS 자료분류 &gt; 문서" +
            "분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 공문</string>\r\n  <string>PMIS 자료분류 &g" +
            "t; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 공문 &gt; 공조장비설치공사</string>\r\n  <" +
            "string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 공문 &gt; 시험<" +
            "/string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt" +
            "; 공문 &gt; 에어컨 설치공사</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online" +
            " 문서관리 &gt; 서신문서 &gt; 기타 (E-Mail 등)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt" +
            "; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 부적합 사항 보고서</string>\r\n  <string>PMIS 자료분류 &g" +
            "t; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 부적합 사항 보고서 &gt; 부적합 사항 조치결과</s" +
            "tring>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; " +
            "부적합 사항 보고서 &gt; 부적합 사항 최종확인</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &g" +
            "t; Online 문서관리 &gt; 서신문서 &gt; 안전 부적합 사항 보고서</string>\r\n  <string>PMIS 자료분류 &gt; 문" +
            "서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 안전 부적합 사항 보고서 &gt; 안전 부적합 사항 조치결과<" +
            "/string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt" +
            "; 안전 부적합 사항 보고서 &gt; 안전 부적합 사항 최종확인</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &g" +
            "t; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 작업지시서</string>\r\n  <string>PMIS 자료분류 &gt; 문" +
            "서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 서신문서 &gt; 회의록</string>\r\n  <string>PMIS 자료분류 " +
            "&gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 시공문서 &gt; 검측요청서</string>\r\n  <string>PM" +
            "IS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 시공문서 &gt; 결함 통보서</string>\r\n  <" +
            "string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Online 문서관리 &gt; 시공문서 &gt; 안전 시정 지시서</" +
            "string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Transmittal (계약업체)</string" +
            ">\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; Transmittal (시공사)</string>\r\n  <s" +
            "tring>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; 문서 발신 (지시서)</string>\r\n  <string>PMIS 자료" +
            "분류 &gt; 문서분류체계 &gt; 공통 &gt; 문서 발신 (지시서) &gt; 지시서 - 발신</string>\r\n  <string>PMIS 자" +
            "료분류 &gt; 문서분류체계 &gt; 공통 &gt; 문서 발신 (회의록) &gt; 회의록 - 발신</string>\r\n  <string>PMIS " +
            "자료분류 &gt; 문서분류체계 &gt; 공통 &gt; 보고서 &gt; 기타보고서</string>\r\n  <string>PMIS 자료분류 &gt; " +
            "문서분류체계 &gt; 공통 &gt; 인허가</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; 인" +
            "허가 &gt; 기타 - 인허가</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 공통 &gt; 인허가 &gt;" +
            " 착공계서류</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; MP단계 &gt; 보고서 - MP" +
            "단계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; Shop Dwg (시공사)</string" +
            ">\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; Shop Dwg (시공사) &gt; 도면 - Shop Dw" +
            "g (시공사)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; Shop Dwg (시공사) &g" +
            "t; 도면 - Shop Dwg (시공사) &gt; 기계 - Shop Dwg (시공사)</string>\r\n  <string>PMIS 자료분류 &g" +
            "t; 문서분류체계 &gt; 설계 &gt; 계약도면(입찰도면)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt;" +
            " 설계 &gt; 계약도면(입찰도면) &gt; 계산서 - 계약도면(입찰도면)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분" +
            "류체계 &gt; 설계 &gt; 계약도면(입찰도면) &gt; 도면 - 계약도면(입찰도면)</string>\r\n  <string>PMIS 자료분류 &" +
            "gt; 문서분류체계 &gt; 설계 &gt; 계약도면(입찰도면) &gt; 시방서 - 계약도면(입찰도면)</string>\r\n  <string>PMI" +
            "S 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 계획설계 &gt; 보고서 - 계획설계</string>\r\n  <string>PMIS 자료" +
            "분류 &gt; 문서분류체계 &gt; 설계 &gt; 기본설계 &gt; 보고서 - 기본설계</string>\r\n  <string>PMIS 자료분류 &" +
            "gt; 문서분류체계 &gt; 설계 &gt; 설계변경도면/도서</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt;" +
            " 설계 &gt; 설계변경도면/도서 &gt; 도면 - 설계변경도면/도서</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계" +
            " &gt; 설계 &gt; 설계변경도면/도서 &gt; 도면 - 설계변경도면/도서 &gt; 건축 - 설계변경도면/도서</string>\r\n  <str" +
            "ing>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 설계변경도면/도서 &gt; 도면 - 설계변경도면/도서 &gt; 인테리어-설" +
            "계변경도면/도서</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 설계변경도면/도서 &gt; 도" +
            "면 - 설계변경도면/도서 &gt; 전기 - 설계변경도면/도서</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt;" +
            " 설계 &gt; 설계변경도면/도서 &gt; 도면 - 설계변경도면/도서 &gt; 조경 - 설계변경도면/도서</string>\r\n  <string>P" +
            "MIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 설계변경도면/도서 &gt; 입주사요청사항</string>\r\n  <string>PMI" +
            "S 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 실시설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &" +
            "gt; 설계 &gt; 실시설계 &gt; 계산서 - 실시설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; " +
            "설계 &gt; 실시설계 &gt; 도면 - 실시설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &g" +
            "t; 실시설계 &gt; 시방서 - 실시설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 인" +
            "테리어단계 &gt; 기본/기획설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 설계 &gt; 인테리어단계" +
            " &gt; 실시설계</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 안전/환경 &gt; 계획 &gt; 안전관" +
            "리계획서</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 안전/환경 &gt; 기타 &gt; 안전점검일지</s" +
            "tring>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 안전/환경 &gt; 기타 &gt; 위험성평가</string>\r\n" +
            "  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 안전/환경 &gt; 보고서</string>\r\n  <string>PMIS 자료분" +
            "류 &gt; 문서분류체계 &gt; 안전/환경 &gt; 보고서 &gt; 사고 보고서(산재)</string>\r\n  <string>PMIS 자료분류 " +
            "&gt; 문서분류체계 &gt; 안전/환경 &gt; 안전 부적합사항 &gt; 안전 부적합 사항 보고서</string>\r\n  <string>PMIS" +
            " 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 계획 &gt; 공종별 검사 계획서(ITP&amp;ITC)</string>\r\n  <stri" +
            "ng>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 계획 &gt; 품질 관리 계획서</string>\r\n  <string>PMIS" +
            " 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 부적합사항 &gt; 부적합 사항 보고서</string>\r\n  <string>PMIS 자료" +
            "분류 &gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(KOM) &gt; 시공계획서</string>\r\n  <string>PMIS 자료분류 " +
            "&gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(PCM)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &g" +
            "t; 품질 &gt; 시공계획서(PCM) &gt; 건축 - 시공계획서(PCM)</string>\r\n  <string>PMIS 자료분류 &gt; 문서" +
            "분류체계 &gt; 품질 &gt; 시공계획서(PCM) &gt; 기계 - 시공계획서(PCM)</string>\r\n  <string>PMIS 자료분류 " +
            "&gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(PCM) &gt; 소방기계 - 시공계획서(PCM)</string>\r\n  <string>P" +
            "MIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(PCM) &gt; 소방전기 - 시공계획서(PCM)</string>\r\n  " +
            "<string>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(PCM) &gt; 전기 - 시공계획서(PCM)</stri" +
            "ng>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 시공계획서(PCM) &gt; 조경 - 시공계획서(PCM" +
            ")</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 자재/장비 공급승인서 (DP2)</stri" +
            "ng>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 자재/장비 공급승인서 (DP2) &gt; 건축 - 자재" +
            "/장비 공급승인서 (DP2)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 자재/장비 공급승" +
            "인서 (DP2) &gt; 기계 - 자재/장비 공급승인서 (DP2)</string>\r\n  <string>PMIS 자료분류 &gt; 문서분류체계 &" +
            "gt; 품질 &gt; 자재/장비 공급승인서 (DP2) &gt; 전기 - 자재/장비 공급승인서 (DP2)</string>\r\n  <string>PM" +
            "IS 자료분류 &gt; 문서분류체계 &gt; 품질 &gt; 자재/장비 공급승인서 (DP2) &gt; 조경 - 자재/장비 공급승인서 (DP2)</" +
            "string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리</string>\r\n  <string>PMIS 자료분류" +
            " &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리업무일지 &gt; 배관공사</string>\r\n  <string>PMI" +
            "S 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리업무일지 &gt; 배선공사</string>\r\n  <stri" +
            "ng>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리업무일지 &gt; 분야별감리업무일지</strin" +
            "g>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리업무일지 &gt; 시험</s" +
            "tring>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리업무일지 &gt; 책" +
            "임감리업무일지</string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 감리업무관리 &gt; 감리월" +
            "간보고</string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 시공보고관리 &gt; 월간업무보고<" +
            "/string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 시공보고관리 &gt; 작업일보</strin" +
            "g>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 시공보고관리 &gt; 주간업무보고</string>\r\n" +
            "  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 시공보고관리 &gt; 주간업무보고 &gt; 배관공사</str" +
            "ing>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 시공관리 &gt; 입주사협의 &gt; 회의자료</string>\r\n " +
            " <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 전자도서관리 &gt; 사업일반 &gt; 사업계획</string>\r\n  <stri" +
            "ng>PMIS 자료분류 &gt; 시공자료분류 &gt; 품질/안전/ 환경관리 &gt; 품질관리 &gt; 자재검수요청서</string>\r\n  <st" +
            "ring>PMIS 자료분류 &gt; 시공자료분류 &gt; 품질/안전/ 환경관리 &gt; 품질관리 &gt; 자재검수요청서 &gt; 건축 - 자재검" +
            "수요청서</string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 품질/안전/ 환경관리 &gt; 품질관리 &gt; 자" +
            "재검수요청서 &gt; 기계 - 자재검수요청서</string>\r\n  <string>PMIS 자료분류 &gt; 시공자료분류 &gt; 품질/안전/ 환" +
            "경관리 &gt; 품질관리 &gt; 자재검수요청서 &gt; 전기 - 자재검수요청서</string>\r\n  <string>PMIS 자료분류 &gt; " +
            "시공자료분류 &gt; 품질/안전/ 환경관리 &gt; 품질관리 &gt; 자재검수요청서 &gt; 조경 - 자재검수요청서</string>\r\n  <st" +
            "ring>PMIS 자료분류 &gt; 시공자료분류 &gt; 품질/안전/ 환경관리 &gt; 품질관리 &gt; 현장통합점검일지</string>\r\n  " +
            "<string>보안문서분류체계 &gt; 보고서</string>\r\n  <string>보안문서분류체계 &gt; 보고서 &gt; 입주사 월간보고서</" +
            "string>\r\n  <string>보안문서분류체계 &gt; 원가</string>\r\n  <string>보안문서분류체계 &gt; 원가 &gt; 기성" +
            " &gt; 공사기성부분 검사원</string>\r\n  <string>보안문서분류체계 &gt; 원가 &gt; 기성 &gt; 공사비 - 기성</str" +
            "ing>\r\n  <string>보안문서분류체계 &gt; 원가 &gt; 기성 &gt; 용역비 - 기성</string>\r\n  <string>보안문서분" +
            "류체계 &gt; 원가 &gt; 변경/정산 &gt; 공사비 - 변경/정산</string>\r\n  <string>보안문서분류체계 &gt; 원가 &gt" +
            "; 변경/정산 &gt; 기타 - 변경/정산</string>\r\n  <string>보안문서분류체계 &gt; 정보보안 &gt; 인원보안지침 &gt; " +
            "비밀유지 서약서(외부업체 및 대표자)</string>\r\n</ArrayOfString>")]
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
    }
}
