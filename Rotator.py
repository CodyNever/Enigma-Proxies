import Proxy_Finder
import file_logger

rotator_iteration = 10
rotator_size = 5

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

    if proxy_id >= len(proxies):
        proxy_id = 0

    if len(proxies) == 0:
        file_logger.log('Error: not proxies found')
        return ''

    proxy = proxies[proxy_id]
    proxy_id += 1
    total_iterations += 1
    return proxy


def create_new(size=10, iterations=100):
    file_logger.log('Create new rotator')
    global rotator_iteration
    global rotator_size
    global proxies

    rotator_size = size
    rotator_iteration = iterations

    proxies = Proxy_Finder.start_checking(size)

    if proxies is None:
        proxies = []


for x in range(0, 5):
    print(get_proxy())
print('Done')
