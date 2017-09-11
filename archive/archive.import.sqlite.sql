insert into archive (
	id,
	description,
	file_seq,
	archive_type,
	metadata,
	created
) values (
	@id,
	@description,
	@file_seq,
	@type,
	@metadata,
	@created
);