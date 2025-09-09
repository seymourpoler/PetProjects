import { isatty } from 'node:tty';
import { createRequire } from 'node:module';
import util from 'node:util';
import timers from 'node:timers';
import { performance } from 'node:perf_hooks';
import { startTests, collectTests } from '@vitest/runner';
import { setupColors, createColors } from '@vitest/utils';
import { installSourcemapsSupport } from 'vite-node/source-map';
import { s as setupChaiConfig, r as resolveTestRunner, a as resolveSnapshotEnvironment } from '../vendor/index.CROIsoiT.js';
import { a as startCoverageInsideWorker, s as stopCoverageInsideWorker } from '../vendor/coverage.BhYSDdTT.js';
import { g as getWorkerState } from '../vendor/global.7bFbnyXl.js';
import { V as VitestIndex } from '../vendor/index.Hqvcg1pf.js';
import { s as setupCommonEnv } from '../vendor/setup-common.yHaxjRhz.js';
import { c as closeInspector } from '../vendor/inspector.hPQncR7V.js';
import 'chai';
import 'pathe';
import '../path.js';
import 'node:url';
import '../vendor/rpc.BGx7q_k2.js';
import '../vendor/index.BpSiYbpB.js';
import '../vendor/benchmark.B6pblCp2.js';
import '@vitest/runner/utils';
import '../vendor/index.BJmtb_7W.js';
import '../vendor/env.2ltrQNq0.js';
import 'std-env';
import '../vendor/run-once.Db8Hgq9X.js';
import '../vendor/vi.DXACdGTu.js';
import '../vendor/_commonjsHelpers.BFTU3MAI.js';
import '@vitest/expect';
import '@vitest/snapshot';
import '@vitest/utils/error';
import '../vendor/tasks.DhVtQBtW.js';
import '@vitest/utils/source-map';
import '../vendor/base.CTYV4Gnz.js';
import '../vendor/date.W2xKR2qe.js';
import '@vitest/spy';

async function run(method, files, config, executor) {
  const workerState = getWorkerState();
  await setupCommonEnv(config);
  Object.defineProperty(globalThis, "__vitest_index__", {
    value: VitestIndex,
    enumerable: false
  });
  setupColors(createColors(isatty(1)));
  if (workerState.environment.transformMode === "web") {
    const _require = createRequire(import.meta.url);
    _require.extensions[".css"] = () => ({});
    _require.extensions[".scss"] = () => ({});
    _require.extensions[".sass"] = () => ({});
    _require.extensions[".less"] = () => ({});
  }
  globalThis.__vitest_required__ = {
    util,
    timers
  };
  installSourcemapsSupport({
    getSourceMap: (source) => workerState.moduleCache.getSourceMap(source)
  });
  await startCoverageInsideWorker(config.coverage, executor);
  if (config.chaiConfig) {
    setupChaiConfig(config.chaiConfig);
  }
  const [runner, snapshotEnvironment] = await Promise.all([
    resolveTestRunner(config, executor),
    resolveSnapshotEnvironment(config, executor)
  ]);
  config.snapshotOptions.snapshotEnvironment = snapshotEnvironment;
  workerState.onCancel.then((reason) => {
    var _a;
    closeInspector(config);
    (_a = runner.onCancel) == null ? void 0 : _a.call(runner, reason);
  });
  workerState.durations.prepare = performance.now() - workerState.durations.prepare;
  const { vi } = VitestIndex;
  for (const file of files) {
    workerState.filepath = file;
    if (method === "run") {
      await startTests([file], runner);
    } else {
      await collectTests([file], runner);
    }
    vi.resetConfig();
    vi.restoreAllMocks();
  }
  await stopCoverageInsideWorker(config.coverage, executor);
}

export { run };
