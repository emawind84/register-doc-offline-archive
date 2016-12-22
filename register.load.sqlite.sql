select
	docno,
	title,
	ORGANIZATION,
	REVISION,
	revision_date,
	registered,
	registered_BY,
	int_cd,
	descr,
	discipline,
	review_status,
	doc_status,
	DOC_TYPE,
	DOC_VERSION,
	doc_current
from register
where 1=1