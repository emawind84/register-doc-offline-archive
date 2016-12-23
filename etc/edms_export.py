#title Export EDMS by FBS

from java.io import *
from pmis.common.util import *

taskExec = Beans.taskExecutor

limit_results = 9999
res = sql('''
select t5.DOC_CLSS_NAME, t1.MATRL_DRAW_NO, t4.MATRL_NAME, t2.REVID, t2.TITLE, t3.FILEPATH, t4.VERSION
from doc_dgn_cat t1, comm_attch_file t2, pmis_edms t3, doc_hist t4, doc_clss t5
where t1.doc_seq = t4.doc_seq
and t2.file_seq = t4.file_seq
and t2.revid = t3.REVID
and t1.pjt_cd = 'GLB_PMIS'
and t1.FBS_CD = t5.doc_cd
and t1.DEL_YN = '0'
and t2.format_div = '0'
and rownum <= ?
;''', limit_results)

f = File('C:\\Users\\Disco\workspace_4.5\\backup\\register')
f.mkdirs()

print f.getAbsolutePath()

for r in res:
    #print r

    efile = EdmsFile(r['FILEPATH'], r['TITLE'])

    ff = File(f.getAbsolutePath(), FileUtil.sanitizeFileName(r['MATRL_DRAW_NO']))
    ff.mkdirs()
    
    ff = File(ff.getAbsolutePath(), str(r['VERSION']))
    ff.mkdirs()

    print 'Creating path: ' + u''.join(ff.getAbsolutePath()).encode('utf-8')

    print '###' + u''.join(efile.name).encode('utf-8').strip()
    nf = File(ff.getAbsolutePath(), FileUtil.sanitizeFileName(efile.name))

    if nf.exists():
        print 'File already present skipping...'
        continue

    try:
        #FileUtil.copyThread(efile, nf, taskExec)
        print '### copy'
    except:
        print 'File not found, skipping file: ' + efile.toString()