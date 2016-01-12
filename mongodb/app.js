// Retrieve
var mongoClient = require('mongodb').MongoClient;
var url = "mongodb://localhost:27017/exampleDb";
// Connect to the db
mongoClient.connect(url, function(err, db) {
  if(err) { return console.log(err); }

  var collection = db.collection('test');
  var docs = [{mykey:1}, {mykey:2}, {mykey:3}];

  collection.insert(docs, {w:1}, function(err, result) {
    if(err) { return console.log('insert:',err); }
    console.log('insert: ', result);
  });
  collection.findOne({mykey:1}, function(err, item) {
    if(err) { return console.log('findOne',err); }
    return console.log('find one', item);
  });
  collection.remove({mykey:2}, {w:1}, function(err, result) {
    console.log('remove: ', result);
    db.close();
  });
});
