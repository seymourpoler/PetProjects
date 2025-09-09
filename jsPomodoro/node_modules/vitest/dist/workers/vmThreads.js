import { a as createThreadsRpcOptions } from '../vendor/utils.DkxLWvS1.js';
import { r as runVmTests } from '../vendor/vm.BrDS6p7h.js';
import '@vitest/utils';
import 'node:vm';
import 'node:url';
import 'pathe';
import '../chunks/runtime-console.O41g23Zj.js';
import 'node:stream';
import 'node:console';
import 'node:path';
import '../vendor/date.W2xKR2qe.js';
import '@vitest/runner/utils';
import '../vendor/global.7bFbnyXl.js';
import '../vendor/env.2ltrQNq0.js';
import 'std-env';
import '../vendor/execute.Dx503nGn.js';
import 'node:fs';
import 'vite-node/client';
import 'vite-node/utils';
import '@vitest/utils/error';
import '../path.js';
import '../vendor/base.CTYV4Gnz.js';
import 'node:module';
import 'vite-node/constants';

class ThreadsVmWorker {
  getRpcOptions(ctx) {
    return createThreadsRpcOptions(ctx);
  }
  runTests(state) {
    return runVmTests("run", state);
  }
  collectTests(state) {
    return runVmTests("collect", state);
  }
}
var vmThreads = new ThreadsVmWorker();

export { vmThreads as default };
