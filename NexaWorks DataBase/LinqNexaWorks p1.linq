<Query Kind="Statements">
  <Connection>
    <ID>e19d4be1-b7d5-406e-bc4f-6fc6ec42f90e</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>NexaWorks</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

{
	//all variable
    int productId1 = 1;//products
    int productId3 = 3;
    int versionId3 = 3;//versions
    int versionId6 = 6;
    int versionId9 = 9;
	DateOnly dateStart = new DateOnly(2023,01,01);//dates
	DateOnly dateEnd = new DateOnly(2023,12,31);
	List<string> allWords = new List<string>{"utilisateur"};//list words
	
	//1
    // Requête pour les tickets non résolus
    var GetAllTicketsNotResolved = Tickets
        .Where(t => t.IsResolved == false)
        .ToList();
    // Affichage des résultats
    GetAllTicketsNotResolved.Dump();/**/
	
	//2
    // Requête pour les tickets non résolus d'un produit spécifique
    var GetAllTicketsNotResolvedOfThisProductID = Tickets
        .Where(t => t.IsResolved == false 
            && t.AssociatedVersionOS.VersionKey.ProductKeyId == productId1)
        .ToList();
    // Affichage des résultats
    GetAllTicketsNotResolvedOfThisProductID.Dump();/**/
	
	//3
    // Requête pour les tickets non résolus d'une version spécifique
    var GetAllTicketsNotResolvedOfThisVersionID = Tickets
        .Where(t => t.IsResolved == false 
            && t.AssociatedVersionOS.VersionKeyId == versionId3)
        .ToList();
    // Affichage des résultats
    GetAllTicketsNotResolvedOfThisVersionID.Dump();/**/
	
	//4
    var GetAllTicketsOfThisProductIDInThisTimeLap = Tickets
        .Where(t => t.AssociatedVersionOS.VersionKey.ProductKeyId == productId1
            && t.DateCreat >= dateStart
            && t.DateCreat <= dateEnd);
	GetAllTicketsOfThisProductIDInThisTimeLap.Dump();/**/
	
	//5
	var GetAllTicketsOfThisVersionIDInThisTimeLap = Tickets
		.Where(t => t.AssociatedVersionOS.VersionKeyId == versionId3
            && t.DateCreat >= dateStart
            && t.DateCreat <= dateEnd);
	GetAllTicketsOfThisVersionIDInThisTimeLap.Dump();/**/
	
	//6
	var GetAllTicketsNotResolvedWithTheseWords = Tickets
		.Where(t => t.IsResolved == false
            && t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsNotResolvedWithTheseWords.Dump();/**/
	
	//7
	var GetAllTicketsNotResolvedOfThisProductIDWithTheseWords = Tickets
		.Where(t => t.IsResolved == false
    		&& t.AssociatedVersionOS.VersionKey.ProductKeyId == productId3
    		&& t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsNotResolvedOfThisProductIDWithTheseWords.Dump();/**/
	
	//8
	var GetAllTicketsNotResolvedOfThisVersionIDWithTheseWords = Tickets
		.Where(t => t.IsResolved == false
    		&& t.AssociatedVersionOS.VersionKeyId == versionId6
    		&& t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsNotResolvedOfThisVersionIDWithTheseWords.Dump();/**/
	
	//9
	var GetAllTicketsOfThisProductIDWithTheseWordsInThisTimeLap = Tickets
		.Where(t => t.AssociatedVersionOS.VersionKey.ProductKeyId == productId3
    		&& t.Description != null
    		&& t.DateCreat >= dateStart
    		&& t.DateCreat <= dateEnd)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsOfThisProductIDWithTheseWordsInThisTimeLap.Dump();/**/
	
	//10
	var GetAllTicketsOfThisVersionIDWithTheseWordsInThisTimeLap = Tickets
		.Where(t => t.AssociatedVersionOS.VersionKeyId == versionId9
    		&& t.Description != null
    		&& t.DateCreat >= dateStart
    		&& t.DateCreat <= dateEnd)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsOfThisVersionIDWithTheseWordsInThisTimeLap.Dump();/**/
	
	
	
	
}