rem @echo off

set forkroot=%enlistmentroot%\..\%2

mkdir %forkroot%
cd /d %forkroot%

hg clone %enlistmentroot% %forkroot%
cd %forkroot%
hg pull -u %1
