if not exists (select 1 from dbo.[Employee])
begin
	insert into dbo.[Employee] 
	(PayrollNumber, Forename, Surname, DateOfBirth, Telephone, Mobile, [Address], Address2, Postcode, EMailHome, StartDate)
	values
	('COOP08', 'John', 'William', convert(date, '26/01/1955', 103), '12345678', '987654231', '12 Foreman road', 'London', 'GU12 6JW','nomadic20@hotmail.co.uk', convert(date, '18/04/2013', 103)),
	('JACK13', 'Jerry', 'Jackson', convert(date, '11/5/1974', 103), '2050508', '6987457', '115 Spinney Road', 'Luton', 'LU33DF', 'gerry.jackson@bt.com', convert(date, '18/04/2013', 103))
end
