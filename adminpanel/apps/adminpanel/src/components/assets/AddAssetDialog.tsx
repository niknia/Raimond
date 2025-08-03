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

interface AddAssetDialogProps {
  opened: boolean;
  onClose: () => void;
  onSave: (data: any) => void;
}

const emptyAsset: Asset = {
  id: '',
  name: '',
  type: '',
  category: '',
  vendor: '',
  model: '',
  serialNumber: '',
  purchaseDate: '',
  warrantyExpiry: '',
  location: '',
  status: 'active',
  assignedTo: '',
  cost: 0,
  maintenanceSchedule: '',
  lastMaintenanceDate: '',
  nextMaintenanceDate: '',
  specifications: {},
  notes: '',
  maintenanceHistory: [],
  riskLevel: 'low',
  installationDate: '',
  expectedLifespan: '',
  ipAddress: '',
  macAddress: '',
};

export function AddAssetDialog({ opened, onClose, onSave }: AddAssetDialogProps) {
  return (
    <Modal
      opened={opened}
      onClose={onClose}
      title="Add New Asset"
      size="xl"
      centered
    >
      <EditAssetForm
        asset={emptyAsset}
        onSave={(data) => {
          onSave({ ...data, id: crypto.randomUUID() });
          onClose();
        }}
        onCancel={onClose}
      />
    </Modal>
  );
} 