"""logger.py - Copyright Ryan Moody 2021"""
import logging
logging.basicConfig(level=logging.INFO)


def log_test_fail(test_executed, assertion_id):
    """Logs the given test as having failed on the given assertion"""
    test_failed = 'Test %s failed' % test_executed.__name__
    logging.error(test_failed)
    assertion_error = 'Assertion %s failed' % assertion_id
    logging.error(assertion_error)


def log_timeout(test_executed):
    """Logs the given test as having timed-out"""
    test_timed_out = 'Test %s failed (timeout)' % test_executed.__name__
    logging.error(test_timed_out)


def log_test_pass(test_executed):
    """Logs the given test as having passed"""
    test_passed = 'Test %s passed' % test_executed.__name__
    logging.info(test_passed)


def log_results(tests_passed, tests_failed):
    """Logs the given number of test passes and test failures"""
    results = 'Tests passed = %d, Tests failed = %d' % (tests_passed, tests_failed)
    logging.info(results)
