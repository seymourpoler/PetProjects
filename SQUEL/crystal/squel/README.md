# Start development
- crystal init lib SQUEL
- add to at the end of `shard.yml`
```
development_dependencies:
   minitest:
     github: ysbaddaden/minitest.cr
     version: "0.3.6"
```
- execute in cmd ```shards install```
- run tests, executing in cmd ``` crystal run test/learning_test.cr ```
# squel

TODO: Write a description here

## Installation

Add this to your application's `shard.yml`:

```yaml
dependencies:
  squel:
    github: [your-github-name]/squel
```

## Usage

```crystal
require "squel"
```

TODO: Write usage instructions here

## Development

TODO: Write development instructions here

## Contributing

1. Fork it ( https://github.com/[your-github-name]/squel/fork )
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -am 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create a new Pull Request

## Contributors

- [[your-github-name]](https://github.com/[your-github-name])  - creator, maintainer
