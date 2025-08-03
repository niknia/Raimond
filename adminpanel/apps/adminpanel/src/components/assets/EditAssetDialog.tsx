'use client';

import { Modal } from '@mantine/core';
import { EditAssetForm } from './EditAssetForm';

interface Asset {
  id: string;
  name: string;
  type: string;
  category: string;
  vendor: string;
  model: string;
  serialNumber: string;
  purchaseDate: string;
  warrantyExpiry: string;
  location: string;
  status: string;
  assignedTo: string;
  cost: number;
  maintenanceSchedule: string;
  lastMaintenanceDate: string;
  nextMaintenanceDate: string;
  specifications: Record<string, any>;
  notes: string;
  maintenanceHistory: any[];
  riskLevel: string;
  installationDate: string;
  expectedLifespan: string;
  ipAddress: string;
  macAddress: string;
}

interface EditAssetDialogProps {
  opened: boolean;
  onClose: () => void;
  asset: Asset;
  onSave: (data: any) => void;
}

export function EditAssetDialog({ opened, onClose, asset, onSave }: EditAssetDialogProps) {
  return (
    <Modal
      opened={opened}
      onClose={onClose}
      title="Edit Asset"
      size="xl"
      centered
    >
      <EditAssetForm
        asset={asset}
        onSave={(data) => {
          onSave(data);
          onClose();
        }}
        onCancel={onClose}
      />
    </Modal>
  );
} 