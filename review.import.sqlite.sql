insert into review_info (
	docno,
	doc_version,
	review_date,
	review_status,
	reviewed_by,
	review_note
) values (
	@docno,
	@version,
	@review_date,
	@review_status,
	@reviewed_by,
	@review_note
);