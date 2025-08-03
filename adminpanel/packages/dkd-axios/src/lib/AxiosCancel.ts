import type { AxiosRequestConfig, Canceler } from 'axios';
import axios from 'axios';

export interface PendingType {
  url: string | undefined;
  method: string | undefined;
  params: unknown;
  data: unknown;
  cancel: Canceler;
}

export class AxiosCanceler {
  private pendingMap: Map<string, PendingType[]>;

  constructor() {
    this.pendingMap = new Map<string, PendingType[]>();
  }

  /**
   * Add request
   * @param {Object} config
   * @param {Function} cancel
   */
  addPending(config: AxiosRequestConfig, cancel: Canceler) {
    this.removePending(config);
    const url = config.url;
    if (!url) {
      return;
    }
    config.cancelToken =
      config.cancelToken ||
      new axios.CancelToken((cancel) => {
        if (!this.pendingMap.has(url)) {
          this.pendingMap.set(url, []);
        }
        this.pendingMap.get(url)?.push({
          url,
          method: config.method,
          params: config.params,
          data: config.data,
          cancel,
        });
      });
  }

  /**
   * @description: Clear all pending
   */
  removeAllPending() {
    for (const [_, pendings] of this.pendingMap) {
      for (const { cancel } of pendings) {
        cancel('Clear all pending');
      }
    }
    this.pendingMap.clear();
  }

  /**
   * Removal request
   * @param {Object} config
   */
  removePending(config: AxiosRequestConfig) {
    const url = config.url;
    if (!url) {
      return;
    }
    const pendings = this.pendingMap.get(url);
    if (pendings) {
      const index = pendings.findIndex(
        (pending) =>
          pending.method === config.method &&
          JSON.stringify(pending.params) === JSON.stringify(config.params) &&
          JSON.stringify(pending.data) === JSON.stringify(config.data)
      );
      if (index > -1) {
        pendings.splice(index, 1);
      }
      if (pendings.length === 0) {
        this.pendingMap.delete(url);
      }
    }
  }
}
