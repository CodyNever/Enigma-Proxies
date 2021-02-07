import Proxy_Finder
import random

rotator_iteration = 100
rotator_size = 10

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

    if proxy_id > len(proxies)-1:
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

    for index in range(size):
        proxies.append(random.randint(0, 5))
    pass
# for x in range(0, 500):
#     print(get_proxy())
