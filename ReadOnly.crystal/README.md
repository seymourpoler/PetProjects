# ReadOnly

readonly structures

## Installation

```yaml
dependencies:
  ReadOnly:
    github: seymourpoler/ReadOnly
```

## Development

1. crystal init lib ReadOnly
2. cd ReadOnly
3. git clone https://github.com/f/guardian.git && cd guardian
4. crystal build --release ./dev/guardian/src/guardian.cr -o ./guardian
5. guardian --init
6. edit .guardian.yml and the content is:

files: ./src/*.cr
run: crystal spec
---
files: ./spec/*.cr
run: crystal spec
---
files: ./shard.yml
run: crystal deps
---

## Contributing

1. Fork it ( https://github.com/seymourpoler/ReadOnly/fork )
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -am 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create a new Pull Request

## Contributors

- [[Seymour Poler]](https://github.com/seymourpoler)  - creator, maintainer