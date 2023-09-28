# `.Map` method is broken in net8rc1

branches:

1. _blazor-net7-works_: this is simplest form of our sln, working as expected.
1. _blazor-net8-broken_: just moving to .net8rc1 breaks router.
1. **plain-net7-works**: to verify the issue is not related to blazor: router works as expected.
1. **plain-net8-broken**: router does not work like net7.

run on any branch, the call below should end up in the controller, not the fallback html file.

```shell
curl "https://localhost:7261/subpath/ctrl/hi?x=1"
```
