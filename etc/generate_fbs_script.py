# this script generate a csv formatted content with only used classification to use with single fbs selector

ret = sql('''
with criteria as (
    select 
        'GLB_PMIS' as p_pjt_cd,
        2 as p_start_level
    from dual
)
select
  distinct LTRIM( SYS_CONNECT_BY_PATH(
    (case when level < p_start_level and CONNECT_BY_ISLEAF != 1  then '' else DOC_CLSS_NAME end) , ' > '), ' > ' ) DOC_CLSS_NAME,
    doc_cd_path, to_char(level - (p_start_level - 1)) as lvl
from VIEW_doc_clss, criteria
where 1=1
    and (CONNECT_BY_ISLEAF = 1 OR level >= p_start_level)
    and doc_cd in ( 
            select distinct doc_cd 
            from doc_dgn_cat_type
            join doc_dgn_cat on ( doc_dgn_cat_type.doc_seq = doc_dgn_cat.doc_seq )
            where doc_dgn_cat_type.pjt_cd = criteria.p_pjt_cd
            and doc_dgn_cat.del_yn = 0
    )
and pjt_cd = criteria.p_pjt_cd
and doc_div = '6'
connect by prior DOC_CD = UP_DOC_CD
and pjt_cd = criteria.p_pjt_cd
and doc_div = '6'
start with up_doc_cd = '!0!'
and pjt_cd = criteria.p_pjt_cd
and doc_div = '6'
order by doc_clss_name
;''')

for d in ret:
    row = u''.join(d['LVL'])
    row += ',' + u''.join(d['DOC_CLSS_NAME'])
    row += ',' + u''.join(d['DOC_CD_PATH'])
    print row.encode('utf-8')