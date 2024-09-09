// show dbs

// show collections

//use "dbname "

db.createCollections("posts");

//json  ... javascript object notation

db.posts.insertOne({
  title: "how to use useQuery in react ",
  body: "in this post we will be learning about react",
  likes: 3,
  category: "news",
  tags: ["news", "tech"],
  date: Date(),
});

db.posts.insertMany([
  {
    title: "how to use useEffect  in react 18 ",
    body: "in this post we will be learning about react",
    likes: 0,
    category: "news",
    tags: ["news", "tech"],
    date: Date(),
  },

  {
    title: "how to use useState in react ",
    body: "in this post we will be learning about react",
    likes: 1,
    category: "news",
    tags: ["news", "tech"],
    date: Date(),
  },

  {
    title: "how to use useCallback in react ",
    body: "in this post we will be learning about react",
    likes: 3,
    category: "news",
    tags: ["news", "tech"],
    date: Date(),
  },
]);

// data read
//all data read

db.posts.find();

//data read single entry

db.posts.findOne({});

//data read single entry  with data querying

db.posts.findOne({ likes: 0 });

db.posts.findOne({ category: "news" });

//
// the second param  is called as projection by which u can
//read only that data which u desire

db.posts.find({}, { title: 1, date: 1 });
db.posts.find({}, {_id :0, title: 1, date :1});

// syntax error
db.posts.find({}, { title: 1, date: 0 });

// if u dont want to see _id   the projection {_id :0}
// this will work only with id
db.posts.find({}, { _id: 0, title: 1, date: 1 });

//update data

db.posts.find({ title: "how to use useCallback in react " });

// for updation of single entry
// we use updateOne ... first object  param will be query
// and second will be updation object
// third param {upsert : true } is used when search
//query fails in that case it will insert the new
// updation object in the collection

db.posts.updateOne(
  { title: "how to use useCallback in react " },
  { $set: { likes: 4 } }
);

db.posts.updateOne(
  { title: "how to use useEffect  in react 18 " },

  { $set: { title: "How to use useEffect!" } }
);

// by querying it second time nothing will happen
db.posts.updateOne(
  { title: "How to use UseReducer in react 18!" },
  {
    $set: {
      title: "How to use UseReducer in react 18!",
      body: "in this post we will be learning about react",
      likes: 3,
      category: "react",
      tags: ["news", "tech"],
      date: Date(),
    },
  },
  { upsert: true }
);


// if we want to insert another data feild in all the documents  
db.posts.updateMany({}, { $set: { commentBox: [] } });





// if we want to delete one sepecific entry 
// remember search query should be unique


db.posts.deleteOne({title : "kuchbhi"})



//  // remember search query should be comon in many documents


db.posts.deleteMany({ category: "Technology" })




db.posts.aggregate([

  {$group : {_id : "$title"}},

])



// aggregate pipelines limit stage   i.e if u want show only one document from collections 
db.posts.aggregate([ { $limit: 1 } ])




db.posts.aggregate([

  {$group : {_id : "$title"}},

  {$limit :1}

])





db.posts.aggregate([

  // stage 1
  {
    $project: {
      "_id" : 0,
      "title": 1,
      "date" : 1
      
    }
  },

  //stage 2
  {
    $limit: 2
  }
])



db.posts.aggregate([ 
  { 
    $sort: { "likes": 1 } 
  },
  {
    $project: {
      "_id" : 0,
      "title": 1,
      "likes" :1
    }
  },
  {
    $limit: 5
  }
])



db.posts.aggregate([ 
  { $match : { category : "react" } },
 
  { $project: {
    "_id" : 0,
    "title": 1
  }}
])



db.posts.aggregate([
  {
    $addFields: {
      averageLikes: {$avg : "$likes"}
    }
  },
  { $project: {
    "_id" : 0,
    "title": 1,
    "likes" :1,
    "averageLikes" : 1
  }},
  {
    $limit: 5
  }
])




db.posts.aggregate([
  {
    $match: { category: "news" }
  },
  {
    $count: "countofDocuments"
  }
])




// indexing and search 

// indexing u have to create for any collection 
// and have to ptovide  index name 
// if default then no need to pass index feild to $search stage  
db.movies.aggregate([
  {
    $search: {
    
      text: {
        query: "star wars",
        path: "title"
      },
    },
  },
  {
    $project: {
      _id : 0, 
      title: 1,
    }
  },
  {$limit  : 2}
 
])