from datetime import datetime
import Proxy_Finder
import random

rotator_iteration = 10
rotator_size = 3

proxy_id = 0
total_iterations = 0

proxies = []


def get_proxy():
    global proxy_id
    global total_iterations

    if len(proxies) == 0:
        create_new(rotator_size, rotator_iteration)

    if total_iterations >= rotator_iteration:
        total_iterations = 0
        proxy_id = 0
        create_new(rotator_size, rotator_iteration)

    if proxy_id > len(proxies) - 1:
        proxy_id = 0

    proxy = proxies[proxy_id]
    proxy_id += 1
    total_iterations += 1
    return proxy


def create_new(size=10, iterations=100):
    global rotator_iteration
    global rotator_size
    global proxies

    rotator_size = size
    rotator_iteration = iterations

    proxies = Proxy_Finder.start_checking(size)


i = datetime.now()
for x in range(0, 30):
    print(get_proxy())
print(f'Затраченое время: {datetime.now() - i}')


