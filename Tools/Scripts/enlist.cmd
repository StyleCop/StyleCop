rem @echo off

set forkroot=%enlistmentroot%\..\%2

mkdir %forkroot%
cd /d %forkroot%
hg clone %1 %forkroot%
hg pull
hg update