# Board Web API

### Index Page
* [GET] http://lunahc92.tplinkdns.com/api/posts

### Create Post
* [POST] http://lunahc92.tplinkdns.com/api/posts/create
```
POST /api/posts/create HTTP/1.1
Host: lunahc92.tplinkdns.com
Content-Type: application/json

{
  "title" : "This is Title",
  "creator" : "This is Creator",
  "text" : "This is Text"
}
```

### Read Post
* [GET] http://lunahc92.tplinkdns.com/api/posts/read/{id}

### Update Post
* [PUT] http://lunahc92.tplinkdns.com/api/posts/update/{id}
```
POST /api/posts/update HTTP/1.1
Host: lunahc92.tplinkdns.com
Content-Type: application/json

{
  "id" : "This is Id",
  "title" : "This is Title",
  "text" : "This is Text"
}
```

### Delete Post
* [DELETE] http://lunahc92.tplinkdns.com/api/posts/delete/{id}

### List Post
* [GET] http://lunahc92.tplinkdns.com/api/posts/list?page={page#}
